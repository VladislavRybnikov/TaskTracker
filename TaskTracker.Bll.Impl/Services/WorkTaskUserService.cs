﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Bll.Abstract.Services;
using TaskTracker.Common.Results;
using TaskTracker.Dto;

namespace TaskTracker.Bll.Impl.Services
{
    public class WorkTaskUserService : IWorkTaskUserService
    {
        public Task<Result> CreateWorkTaskUserAsync(WorkTaskUserDto workTaskUserDto)
        {
            throw new NotImplementedException();
        }

        public Task<Result> DeleteWorkTaskUserAsync(WorkTaskUserDto workTaskUserDto)
        {
            throw new NotImplementedException();
        }

        public Task<Result> UpdateWorkTaskUserAsync(WorkTaskUserDto workTaskUserDto)
        {
            throw new NotImplementedException();
        }
    }
}
