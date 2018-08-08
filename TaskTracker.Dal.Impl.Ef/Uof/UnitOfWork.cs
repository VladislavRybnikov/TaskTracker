using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Dal.Abstract.Repositories;
using TaskTracker.Dal.Abstract.Uof;
using TaskTracker.Dal.Impl.Ef.Base;
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
        private IWorkTaskProgressRepository _workTaskProgressRepository;
        private IWorkTaskDateInfoRepository _workTaskDateInfoRepository;
        private IWorkTaskCategoryRepository _workTaskCategoryRepository;
        private IUserContactsRepository _userContactsRepository;
        private ILocationRepository _locationRepository;
        private IWorkTaskPointRepository _workTaskPointRepository;
        private IWorkTaskPointProgressRepository 
            _workTaskPointProgressRepository;

        public UnitOfWork()
        {
            _context = new TaskTrackerDbContext();
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


        public IWorkTaskCategoryRepository WorkTaskCategoryRepository
        {
            get
            {
                if (_workTaskCategoryRepository == null)
                    _workTaskCategoryRepository = new WorkTaskCategoryRepository(_context);

                return _workTaskCategoryRepository;
            }
        }

        public IWorkTaskDateInfoRepository WorkTaskDateInfoRepository
        {
            get
            {
                if (_workTaskDateInfoRepository == null)
                    _workTaskDateInfoRepository = new WorkTaskDateInfoRepository(_context);

                return _workTaskDateInfoRepository;
            }
        }

        public IWorkTaskProgressRepository WorkTaskProgressRepository
        {
            get
            {
                if (_workTaskProgressRepository == null)
                    _workTaskProgressRepository = new WorkTaskProgressRepository(_context);

                return _workTaskProgressRepository;
            }
        }

        public ILocationRepository LocationRepository
        {
            get
            {
                if (_locationRepository == null)
                    _locationRepository = new LocationRepository(_context);

                return _locationRepository;
            }
        }

        public IUserContactsRepository UserContactsRepository
        {
            get
            {
                if (_userContactsRepository == null)
                    _userContactsRepository 
                        = new UserContactsRepository(_context);

                return _userContactsRepository;
            }
        }

        public IWorkTaskPointRepository WorkTaskPointRepository
        {
            get
            {
                if (_workTaskPointRepository == null)
                    _workTaskPointRepository 
                        = new WorkTaskPointRepository(_context);

                return _workTaskPointRepository;
            }
        }

        public IWorkTaskPointProgressRepository WorkTaskPointProgressRepository
        {
            get
            {
                if (_workTaskPointProgressRepository == null)
                    _workTaskPointProgressRepository 
                        = new WorkTaskPointProgressRepository(_context);

                return _workTaskPointProgressRepository;
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

        public async Task SaveChangesAsync()
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
