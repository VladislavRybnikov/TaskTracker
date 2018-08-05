using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Dal.Abstract.Base;
using TaskTracker.Dal.Abstract.Repositories;
using TaskTracker.Entities.Base;

namespace TaskTracker.UnitTests.Mock
{
    public class MockGenericRepository<TEntity> 
        : IGenericRepository<TEntity> where TEntity : BaseIntIdEntity
    {
        private MockData _mockData = new MockData();

        public void Add(TEntity entity)
        {
            _mockData.Get<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _mockData.Get<TEntity>().Remove(entity);
        }

        public TEntity First(ISpecification<TEntity> specification)
        {
            return _mockData.Get<TEntity>()
                .Where(specification.Criteria.Compile())
                .FirstOrDefault();
        }

        public async Task<TEntity> FirstAsync(ISpecification<TEntity> 
            specification)
        {
            return await Task.Run(() 
                => _mockData.Get<TEntity>()
                .FirstOrDefault(specification.Criteria.Compile()));
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _mockData.Get<TEntity>();
        }

        public IEnumerable<TEntity> GetAll(ISpecification<TEntity> 
            specification)
        {
            return _mockData.Get<TEntity>()
                .Where(specification.Criteria.Compile());
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Task.Run(() => GetAll());
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync
            (ISpecification<TEntity> specification)
        {
            return await Task.Run(() => GetAll(specification));
        }

        public TEntity GetById(int id)
        {
            return _mockData.Get<TEntity>()
                .Find(x => x.Id == id);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await Task.Run(() => GetById(id));
        }

        public void Update(TEntity entity)
        {
            _mockData.Get<TEntity>().RemoveAll(x => x.Id == entity.Id);
            _mockData.Get<TEntity>().Add(entity);
        }
    }
}
