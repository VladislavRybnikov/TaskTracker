using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using TaskTracker.Dal.Abstract.Repositories;
using TaskTracker.Entities;

namespace TaskTracker.Dal.Impl.Ef.Repositories
{
    public class UserContactsRepository : GenericRepository<UserContacts>, IUserContactsRepository
    {
        public UserContactsRepository(DbContext context) : base(context) { }
    }
}
