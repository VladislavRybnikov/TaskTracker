using System;
using System.Collections.Generic;
using System.Text;

namespace TaskTracker.Dto
{
    public class WorkTaskPointDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal ExecutedPercent { get; set; }
        public int PointState { get; set; }
        public string PointSateDescripton { get; set; }
        public string AttachmentPath { get; set; }
    }
}
