using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Dal.Abstract.Base;
using TaskTracker.Entities;

namespace TaskTracker.Dal.Abstract.Repositories
{
    public interface IWorkTaskRepository : IRepository<WorkTask, int>,
        IAsyncRepository<WorkTask, int>
    {
    }
}
