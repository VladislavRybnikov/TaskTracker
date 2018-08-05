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
        public IWorkTaskRepository WorkTaskRepository 
            => new MockWorkTaskRepository();

        public IWorkTaskUserRepository WorkTaskUserRepository 
            => new MockWorkTaskUserRepository();

        public IWorkTaskCategoryRepository WorkTaskCategoryRepository 
            => GenericRepository<WorkTaskCategory>() 
            as IWorkTaskCategoryRepository;

        public IWorkTaskDateInfoRepository WorkTaskDateInfoRepository 
            => GenericRepository<WorkTaskDateInfo>() 
            as IWorkTaskDateInfoRepository;

        public IWorkTaskProgressRepository WorkTaskProgressRepository 
            => GenericRepository<WorkTaskProgress>() 
            as IWorkTaskProgressRepository;

        public ILocationRepository LocationRepository 
            => GenericRepository<Location>() as ILocationRepository;

        public IUserContactsRepository UserContactsRepository 
            => GenericRepository<UserContacts>() as IUserContactsRepository;

        public IWorkTaskPointRepository WorkTaskPointRepository 
            => GenericRepository<WorkTaskPoint>() as IWorkTaskPointRepository;

        public IWorkTaskPointProgressRepository WorkTaskPointProgressRepository 
            => GenericRepository<WorkTaskPointProgress>() 
            as IWorkTaskPointProgressRepository;

        public void Dispose()
        {
            //Mock object.
        }

        public IGenericRepository<TEntity> GenericRepository<TEntity>()
            where TEntity : BaseIntIdEntity
        {
            return new MockGenericRepository<TEntity>();
        }

        public void SaveChanges()
        {
            //Mock object.
        }

        public Task SaveChangesAsync()
        {
            //Mock object.
            return Task.Run(() => { SaveChanges(); });
        }
    }
}
