using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Entities.Base;

namespace TaskTracker.Entities
{
    public class WorkTaskDateInfo : BaseIntIdEntity
    {
        public DateTime CreationDate { get; set; }
        public DateTime Deadline { get; set; }
    }
}
