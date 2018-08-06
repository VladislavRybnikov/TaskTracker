using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Dal.Abstract.Repositories;
using TaskTracker.Dal.Impl.Ef.Specifications;
using TaskTracker.Entities;

namespace TaskTracker.UnitTests.Mock.Repositories
{
    public class MockWorkTaskUserRepository
        : MockGenericRepository<WorkTaskUser>, IWorkTaskUserRepository
    {
        public MockWorkTaskUserRepository(MockData mockData) : base(mockData)
        {
        }

        public async Task<WorkTaskUser> FindByMailAsync(string mail)
        {
            return await FirstAsync
                (new Specification<WorkTaskUser>(x 
                => x.UserContacts.Mail == mail));
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
