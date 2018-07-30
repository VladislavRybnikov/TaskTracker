using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Entities.Base;

namespace TaskTracker.Entities
{
    public class WorkTaskPoint : BaseIntIdEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public WorkTaskPointProgress WorkTaskPointProgress { get; set; }
        public string AttachmentPath { get; set; }
    }
}
