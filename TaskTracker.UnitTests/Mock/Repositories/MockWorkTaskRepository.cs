using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Dal.Abstract.Repositories;
using TaskTracker.Dal.Impl.Ef.Specifications;
using TaskTracker.Entities;

namespace TaskTracker.UnitTests.Mock.Repositories
{
    public class MockWorkTaskRepository
        : MockGenericRepository<WorkTask>, IWorkTaskRepository
    {
        public MockWorkTaskRepository(MockData mockData) : base(mockData)
        {
        }

        public async Task<IEnumerable<WorkTask>> 
            GetAllTasksByManagerIdAsync(int id)
        {
            return await GetAllAsync(new Specification<WorkTask>
                (x => x.Manager.Id == id));
        }

        public async Task<IEnumerable<WorkTask>> 
            GetAllTasksByWorkerIdAsync(int id)
        {
            return await GetAllAsync(new Specification<WorkTask>
                (x => x.Performers.First(y => y.Id == id) != null));
        }
    }
}
