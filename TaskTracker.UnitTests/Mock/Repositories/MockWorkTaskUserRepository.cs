using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Dal.Abstract.Repositories;
using TaskTracker.Entities;

namespace TaskTracker.UnitTests.Mock.Repositories
{
    public class MockWorkTaskUserRepository
        : MockGenericRepository<WorkTaskUser>, IWorkTaskUserRepository
    {
        public Task<WorkTaskUser> FindByMailAsync(string mail)
        {
            throw new NotImplementedException();
        }

        public WorkTaskUser GetWithContacts(int id)
        {
            throw new NotImplementedException();
        }

        public Task<WorkTaskUser> GetWithContactsAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
