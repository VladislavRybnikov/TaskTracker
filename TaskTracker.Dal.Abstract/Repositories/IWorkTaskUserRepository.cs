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
    }
}
