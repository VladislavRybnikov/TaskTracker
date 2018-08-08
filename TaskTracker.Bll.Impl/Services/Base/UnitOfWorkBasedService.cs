using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Dal.Abstract.Uof;

namespace TaskTracker.Bll.Impl.Services.Base
{
    public abstract class UnitOfWorkBasedService
    {
        protected readonly IUnitOfWork _unitOfWork;

        public UnitOfWorkBasedService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
