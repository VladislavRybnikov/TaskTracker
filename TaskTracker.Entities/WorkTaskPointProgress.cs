using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Entities.Base;

namespace TaskTracker.Entities
{
    public class WorkTaskPointProgress : BaseIntIdEntity
    {
        public decimal ExecutedPercent { get; set; }
        public int PointState { get; set; }
        public string PointSateDescripton { get; set; }
    }
}
