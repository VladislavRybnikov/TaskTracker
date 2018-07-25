using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Dal.Abstract.Base;
using TaskTracker.Entities;

namespace TaskTracker.Dal.Abstract.Repositories
{
    public interface IWorkTaskDateInfoRepository 
        : IRepository<WorkTaskDateInfo, int>, 
        IAsyncRepository<WorkTaskDateInfo, int>
    {
    }
}
