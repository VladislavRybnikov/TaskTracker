using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Bll.Abstract.Services;
using TaskTracker.Bll.Impl.Services.Base;
using TaskTracker.Common.Results;
using TaskTracker.Dal.Abstract.Uof;
using TaskTracker.Dto;
using TaskTracker.Entities;
using TaskTracker.Mapping.Base;

namespace TaskTracker.Bll.Impl.Services
{
    public class WorkTaskPointService : UnitOfWorkBasedService, IWorkTaskPointService
    {
        private readonly IMapper<WorkTaskPoint, WorkTaskPointDto> _pointMapper;

        public WorkTaskPointService(IUnitOfWork unitOfWork,
            IMapper<WorkTaskPoint, WorkTaskPointDto> pointMapper) : base(unitOfWork)
        {
            _pointMapper = pointMapper;
        }

        public async Task<Result> UpdateWorkTaskPointAsync
            (WorkTaskPointDto workTaskPointDto)
        {

            throw new NotImplementedException();
        }

    }
}
