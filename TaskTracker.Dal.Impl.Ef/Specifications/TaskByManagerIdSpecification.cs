using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TaskTracker.Entities;

namespace TaskTracker.Dal.Impl.Ef.Specifications
{
    public class TaskByManagerIdSpecification : Specification<WorkTask>
    {
        public TaskByManagerIdSpecification(int managerId) 
            : base(x => x.Manager.Id == managerId)
        {
            AddInclude(x => x.Manager);
        }
    }
}
