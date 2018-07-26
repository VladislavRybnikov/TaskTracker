using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using TaskTracker.Dal.Abstract.Repositories;
using TaskTracker.Dal.Abstract.Uof;
using TaskTracker.Dal.Impl.Ef.Repositories;
using TaskTracker.Entities.Base;

namespace TaskTracker.Dal.Impl.Ef.Uof
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed = false;

        private readonly DbContext _context;

        private IWorkTaskRepository _workTaskRepository;
        private IWorkTaskUserRepository _workTaskUserRepository;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public IWorkTaskRepository WorkTaskRepository
        {
            get
            {
                if (_workTaskRepository == null)
                    _workTaskRepository = new WorkTaskRepository(_context);

                return _workTaskRepository;
            }
        }

        public IWorkTaskUserRepository WorkTaskUserRepository
        {
            get
            {
                if (_workTaskUserRepository == null)
                    _workTaskUserRepository = new WorkTaskUserRepository
                        (_context);

                return _workTaskUserRepository;
            }
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async void SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public IGenericRepository<TEntity> GenericRepository<TEntity>() 
            where TEntity : BaseIntIdEntity
        {
            return new GenericRepository<TEntity>(_context);
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}
