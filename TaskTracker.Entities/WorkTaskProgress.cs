using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Entities.Base;

namespace TaskTracker.Entities
{
    public class WorkTaskProgress : BaseIntIdEntity
    {
        public decimal ExecutedPercent { get; set; }
        public int WorkTaskState { get; set; }

    }
}
