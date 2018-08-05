using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Dal.Abstract.Repositories;
using TaskTracker.Entities;

namespace TaskTracker.UnitTests.Mock.Repositories
{
    public class MockWorkTaskRepository
        : MockGenericRepository<WorkTask>, IWorkTaskRepository
    {
        public Task<IEnumerable<WorkTask>> GetAllTasksByManagerIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WorkTask>> GetAllTasksByWorkerIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
