using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Bll.Abstract.Services;
using TaskTracker.Common.Results;
using TaskTracker.Dto;

namespace TaskTracker.Bll.Impl.Services
{
    public class WorkTaskPointService : IWorkTaskPointService
    {
        public Task<Result> ChangePointProgressAsync
            (WorkTaskPointDto workTaskPointDto)
        {
            throw new NotImplementedException();
        }

        public Task<Result> CreateWorkTaskPointAsync
            (WorkTaskPointDto workTaskPointDto)
        {
            throw new NotImplementedException();
        }
    }
}
