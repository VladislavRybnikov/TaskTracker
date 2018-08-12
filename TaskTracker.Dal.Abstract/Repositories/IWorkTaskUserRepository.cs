using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Dal.Abstract.Base;
using TaskTracker.Entities;

namespace TaskTracker.Dal.Abstract.Repositories
{
    public interface IWorkTaskUserRepository : IGenericRepository<WorkTaskUser>
    {
        WorkTaskUser GetWithContacts(int id);
        Task<WorkTaskUser> GetWithContactsAsync(int id);
        Task<WorkTaskUser> GetByMailAsync(string mail);
        Task<WorkTaskUser> GetByNameAsync(string name);
        Task<WorkTaskUser> GetWithTasks(int id);
    }
}
