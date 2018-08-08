using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Entities;

namespace TaskTracker.Dal.Impl.Ef.Specifications
{
    public class UserInfoByNameSpecification : Specification<WorkTaskUser>
    {
        public UserInfoByNameSpecification(string name)
            : base(u => u.Name == name)
        {
            AddInclude(u => u.UserContacts);
            AddInclude($"{nameof(WorkTaskUser.UserContacts)}" +
                $".{nameof(UserContacts.Location)}");
        }
    }
}
