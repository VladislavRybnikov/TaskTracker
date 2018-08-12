using System;
using System.Collections.Generic;
using System.Text;

namespace TaskTracker.Dto
{
    public class WorkTaskDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime Deadline { get; set; }
        public string CategoryName { get; set; }
        public decimal ExecutedPercent { get; set; }
        public int WorkTaskState { get; set; }
    }
}
