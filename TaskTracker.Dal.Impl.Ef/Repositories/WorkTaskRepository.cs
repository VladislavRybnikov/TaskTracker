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

        public WorkTask GetWithMembers(int id)
        {
            var specification = new WorkTaskWithMembersSpecification(id);

            return First(specification);
        }

        public async Task<WorkTask> GetWithMembersAsync(int id)
        {
            var specification = new WorkTaskWithMembersSpecification(id);

            return await FirstAsync(specification);
        }
    }
}
