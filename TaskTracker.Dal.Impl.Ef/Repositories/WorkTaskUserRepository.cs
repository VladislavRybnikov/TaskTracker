using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Dal.Abstract.Base;
using TaskTracker.Dal.Abstract.Repositories;
using TaskTracker.Dal.Impl.Ef.Specifications;
using TaskTracker.Entities;

namespace TaskTracker.Dal.Impl.Ef.Repositories
{
    public class WorkTaskUserRepository : GenericRepository<WorkTaskUser>,
        IWorkTaskUserRepository
    {
        public WorkTaskUserRepository(DbContext context) : base(context) { }

        public WorkTaskUser GetWithContacts(int id)
        {
            var specification = new UserWithContactsSpecification(id);

            return First(specification);
        }

        public async Task<WorkTaskUser> GetWithContactsAsync(int id)
        {
            var specification = new UserWithContactsSpecification(id);

            return await FirstAsync(specification);
        }

        public async Task<WorkTaskUser> GetByMailAsync(string mail)
        {
            var specification = new UserWithContactsSpecification(mail);

            return await FirstAsync(specification);
        }

        public async Task<WorkTaskUser> GetByNameAsync(string name)
        {
            var specification = new UserInfoByNameSpecification(name);

            return await FirstAsync(specification);
        }

        public async Task<WorkTaskUser> GetWithTasks(int id)
        {
            var specification = new UserWithTasksSpecification(id);

            return await FirstAsync(specification);
        }
}
