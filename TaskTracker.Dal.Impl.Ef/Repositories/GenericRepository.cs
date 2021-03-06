﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Dal.Abstract.Base;
using TaskTracker.Dal.Abstract.Repositories;
using TaskTracker.Dal.Impl.Ef.Specifications;
using TaskTracker.Entities.Base;

namespace TaskTracker.Dal.Impl.Ef.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : BaseIntIdEntity
    {
        private readonly DbContext _context;

        public GenericRepository(DbContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }
        
        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
        
        public TEntity First(ISpecification<TEntity> specification)
        {
            return GetAll(specification).FirstOrDefault();
        }

        public TEntity First(Expression<Func<TEntity, bool>> criteria)
        {
            return First(new Specification<TEntity>(criteria));
        }

        public async Task<TEntity> FirstAsync
            (ISpecification<TEntity> specification)
        {
            var allAsync = await GetAllAsync(specification);

            return allAsync.FirstOrDefault();
        }

        public async Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>>
            criteria)
        {
            return await FirstAsync(new Specification<TEntity>(criteria));
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsEnumerable();
        }

        public IEnumerable<TEntity> GetAll
            (ISpecification<TEntity> specification)
        {
            var queryableResultWithIncludes = specification.Includes
                .Aggregate(_context.Set<TEntity>().AsQueryable(),
                    (current, include) => current.Include(include));

            var secondaryResult = specification.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                (current, include) => current.Include(include));

            return secondaryResult
                .Where(specification.Criteria)
                .AsEnumerable();
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>>
            criteria)
        {
            return GetAll(new Specification<TEntity>(criteria));
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync
            (ISpecification<TEntity> specification)
        {
            var queryableResultWithIncludes = specification.Includes
                .Aggregate(_context.Set<TEntity>().AsQueryable(),
                    (current, include) => current.Include(include));

            var secondaryResult = specification.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                (current, include) => current.Include(include));

            return await secondaryResult
                .Where(specification.Criteria)
                .ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync
            (Expression<Func<TEntity, bool>> criteria)
        {
            return await GetAllAsync(new Specification<TEntity>(criteria));
        }

        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public Task<TEntity> GetByIdAsync(int id)
        {
            return _context.Set<TEntity>().FindAsync(id);
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

    }
}
