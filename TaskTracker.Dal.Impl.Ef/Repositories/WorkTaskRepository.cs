using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Dal.Abstract.Repositories;
using TaskTracker.Dal.Impl.Ef.Specifications;
using TaskTracker.Entities;

namespace TaskTracker.Dal.Impl.Ef.Repositories
{
    public class WorkTaskRepository : GenericRepository<WorkTask>,
        IWorkTaskRepository
    {
        public WorkTaskRepository(DbContext context) : base(context){ }

        public async Task<IEnumerable<WorkTask>> 
            GetAllTasksByManagerIdAsync(int id)
        {
            var specification = new TaskByManagerIdSpecification(id);

            return await GetAllAsync(specification);
        }

        public async Task<IEnumerable<WorkTask>> 
            GetAllTasksByWorkerIdAsync(int id)
        {
            var specification = new TaskByPerformerIdSpecification(id);

            return await GetAllAsync(specification);
        }
    }
}
