using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Dal.Abstract.Repositories;
using TaskTracker.Dal.Abstract.Uof;
using TaskTracker.Entities;
using TaskTracker.Entities.Base;
using TaskTracker.UnitTests.Mock.Repositories;

namespace TaskTracker.UnitTests.Mock
{
    public class MockUnitOfWork : IUnitOfWork
    {
        private readonly MockData _mockData;

        public MockUnitOfWork(MockData mockData)
        {
            _mockData = mockData;
        }

        public IWorkTaskRepository WorkTaskRepository 
            => new MockWorkTaskRepository(_mockData);

        public IWorkTaskUserRepository WorkTaskUserRepository 
            => new MockWorkTaskUserRepository(_mockData);

        public IWorkTaskCategoryRepository WorkTaskCategoryRepository 
            => (IWorkTaskCategoryRepository)
            GenericRepository<WorkTaskCategory>();

        public IWorkTaskDateInfoRepository WorkTaskDateInfoRepository 
            => (IWorkTaskDateInfoRepository)
            GenericRepository<WorkTaskDateInfo>();

        public IWorkTaskProgressRepository WorkTaskProgressRepository 
            => (IWorkTaskProgressRepository)
            GenericRepository<WorkTaskProgress>();

        public ILocationRepository LocationRepository 
            => (ILocationRepository)GenericRepository<Location>();

        public IUserContactsRepository UserContactsRepository 
            => (IUserContactsRepository)GenericRepository<UserContacts>();

        public IWorkTaskPointRepository WorkTaskPointRepository 
            => new MockWorkTaskPointRepository(_mockData);

        public IWorkTaskPointProgressRepository WorkTaskPointProgressRepository 
            => (IWorkTaskPointProgressRepository)
            GenericRepository<WorkTaskPointProgress>();

        public void Dispose()
        {
            //Mock object.
        }

        public IGenericRepository<TEntity> GenericRepository<TEntity>()
            where TEntity : BaseIntIdEntity
        {
            return new MockGenericRepository<TEntity>(_mockData);
        }

        public void SaveChanges()
        {
            //Mock object.
        }

        public Task SaveChangesAsync()
        {
            //Mock object.
            return Task.Run(() => {});
        }
    }
}
