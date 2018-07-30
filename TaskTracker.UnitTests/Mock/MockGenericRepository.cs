using System;
using System.Collections.Generic;
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
        public void Add(TEntity entity)
        {
            MockData.Get<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            MockData.Get<TEntity>().Remove(entity);
        }

        public TEntity First(ISpecification<TEntity> specification)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FirstAsync(ISpecification<TEntity> specification)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return MockData.Get<TEntity>();
        }

        public IEnumerable<TEntity> GetAll(ISpecification<TEntity> specification)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetAllAsync(ISpecification<TEntity> specification)
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(int id)
        {
            return MockData.Get<TEntity>().Find(x => x.Id == id);
        }

        public Task<TEntity> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            MockData.Get<TEntity>().RemoveAll(x => x.Id == entity.Id);
            MockData.Get<TEntity>().Add(entity);
        }
    }
}
