using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Bll.Abstract.Services;
using TaskTracker.Entities;

namespace TaskTracker.Dal.Abstract.Repositories
{
    public interface IWorkTaskPointProgressRepository 
        : IGenericRepository<WorkTaskPointProgress>
    {
    }
}
