using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Dal.Abstract.Repositories;

namespace TaskTracker.Dal.Abstract.Uof
{
    public interface IUnitOfWork : IDisposable
    {
        IWorkTaskRepository WorkTaskRepository { get; }
        IWorkTaskCategoryRepository WorkTaskCategoryRepository { get; }
        IWorkTaskUserRepository WorkTaskUserRepository { get; }
        IUserContactsRepository UserContactsRepository { get; }
        IWorkTaskDateInfoRepository WorkTaskDateInfoRepository { get; }
        IWorkTaskProgressRepository WorkTaskProgressRepository { get; }
        ILocationRepository LocationRepository { get;}

        void SaveChanges();
        void SaveChangesAsync();
    }
}
