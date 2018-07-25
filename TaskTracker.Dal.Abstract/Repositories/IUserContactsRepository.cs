using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Dal.Abstract.Base;
using TaskTracker.Entities;

namespace TaskTracker.Dal.Abstract.Repositories
{
    public interface IUserContactsRepository : IRepository<UserContacts, int>,
        IAsyncRepository<UserContacts, int>
    {
    }
}
