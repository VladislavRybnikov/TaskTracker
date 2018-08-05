using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskTracker.Entities;

namespace TaskTracker.Dal.Impl.Ef.Specifications
{
    public class TaskByPerformerIdSpecification : Specification<WorkTask>
    {
        public TaskByPerformerIdSpecification(int performerId)
            : base(task => task.Performers
            .FirstOrDefault(performer => performer.Id == performerId)
                    != null)
        {
            AddInclude(x => x.Performers);
        }
    }
}
