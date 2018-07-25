using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Entities;

namespace TaskTracker.Dal.Impl.Ef.Specifications
{
    internal class UserWithTasksSpecification : Specification<WorkTaskUser>
    {
        public UserWithTasksSpecification(int userId) 
            : base(u => u.Id == userId)
        {
            AddInclude(u => u.WorkTasks);
        }
    }
}
