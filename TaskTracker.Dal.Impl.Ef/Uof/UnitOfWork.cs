using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Dal.Abstract.Repositories;
using TaskTracker.Dal.Abstract.Uof;

namespace TaskTracker.Dal.Impl.Ef.Uof
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed = false;

        private IWorkTaskRepository _workTaskRepository;
        private IWorkTaskCategoryRepository _workTaskCategoryRepository;
        private IWorkTaskUserRepository _workTaskUserRepository;
        private IUserContactsRepository _userContactsRepository;
        private IWorkTaskDateInfoRepository _workTaskDateInfoRepository;
        private IWorkTaskProgressRepository _workTaskProgressRepository;
        private ILocationRepository _locationRepository;


        public IWorkTaskRepository WorkTaskRepository
        {
            get
            {
                if (_workTaskRepository == null)
                    _workTaskRepository = null;

                return _workTaskRepository;
            }
        }

        public IWorkTaskCategoryRepository WorkTaskCategoryRepository
        {
            get
            {
                if (_workTaskCategoryRepository == null)
                    _workTaskCategoryRepository = null;

                return _workTaskCategoryRepository;
            }
        }

        public IWorkTaskUserRepository WorkTaskUserRepository
        {
            get
            {
                if (_workTaskUserRepository == null)
                    _workTaskUserRepository = null;

                return _workTaskUserRepository;
            }
        }

        public IUserContactsRepository UserContactsRepository
        {
            get
            {
                if (_userContactsRepository == null)
                    _userContactsRepository = null;

                return _userContactsRepository;
            }
        }

        public IWorkTaskDateInfoRepository WorkTaskDateInfoRepository
        {
            get
            {
                if (_workTaskDateInfoRepository == null)
                    _workTaskDateInfoRepository = null;

                return _workTaskDateInfoRepository;
            }
        }

        public IWorkTaskProgressRepository WorkTaskProgressRepository
        {
            get
            {
                if (_workTaskProgressRepository == null)
                    _workTaskProgressRepository = null;

                return _workTaskProgressRepository;
            }
        }

        public ILocationRepository LocationRepository
        {
            get
            {
                if (_locationRepository == null)
                    _locationRepository = null;

                return _locationRepository;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    //_context.Dispose();
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
            throw new NotImplementedException();
        }

        public void SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
