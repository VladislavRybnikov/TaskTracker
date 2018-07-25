using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Entities;

namespace TaskTracker.Dal.Impl.Ef.Specifications
{
    internal class WorkTaskWithMembersSpecification : Specification<WorkTask>
    {
        public WorkTaskWithMembersSpecification(int taskId) : base(t => t.Id == taskId)
        {
            AddInclude(t => t.Manager);
            AddInclude(t => t.Performers);
        }
    }
}
