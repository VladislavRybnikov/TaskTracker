using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Entities.Base;

namespace TaskTracker.Entities
{
    public class WorkTask : BaseIntIdEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public WorkTaskProgress Progress { get; set; }
        public WorkTaskDateInfo DateInfo { get; set; }
        public ICollection<WorkTaskUser> Performers { get; set; } 
        public ICollection<WorkTaskPoint> WorkTaskPoints { get; set; }
        public WorkTaskUser Manager { get; set;}
        public WorkTaskCategory Category { get; set; }
    }
}
