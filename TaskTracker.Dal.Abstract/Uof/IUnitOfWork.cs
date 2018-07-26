using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Dal.Abstract.Repositories;
using TaskTracker.Entities.Base;

namespace TaskTracker.Dal.Abstract.Uof
{
    public interface IUnitOfWork : IDisposable
    {
        IWorkTaskRepository WorkTaskRepository { get; }
        IWorkTaskUserRepository WorkTaskUserRepository { get; }
   
        IGenericRepository<TEntity> GenericRepository<TEntity>() 
            where TEntity : BaseIntIdEntity;

        void SaveChanges();
        void SaveChangesAsync();
    }
}
