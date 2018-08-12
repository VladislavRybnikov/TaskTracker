using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Dal.Abstract.Base;
using TaskTracker.Entities;

namespace TaskTracker.Dal.Abstract.Repositories
{
    public interface IWorkTaskRepository : IGenericRepository<WorkTask>
    {
        Task<IEnumerable<WorkTask>> GetAllTasksByManagerIdAsync(int id);
        Task<IEnumerable<WorkTask>> GetAllTasksByPerformerIdAsync(int id);
    }
}
