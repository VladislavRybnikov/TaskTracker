using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TaskTracker.Entities;

namespace TaskTracker.Dal.Impl.Ef.Specifications
{
    internal class UserWithContactsSpecification : Specification<WorkTaskUser>
    {
        public UserWithContactsSpecification(int userId) 
            : base(u => u.Id == userId)
        {
            AddInclude(u => u.UserContacts);
            AddInclude($"{nameof(WorkTaskUser.UserContacts)}" +
                $".{nameof(UserContacts.Location)}");
        }

        public UserWithContactsSpecification(string mail) 
            : base(u => u.UserContacts.Mail == mail)
        {
            AddInclude(u => u.UserContacts);
        }

    }
}
