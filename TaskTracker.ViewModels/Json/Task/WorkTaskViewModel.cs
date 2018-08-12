using System;
using System.Collections.Generic;
using System.Text;

namespace TaskTracker.ViewModels.Json.Task
{
    public class WorkTaskViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreationDate { get; set; }
        public string Deadline { get; set; }
        public string CategoryName { get; set; }
        public decimal ExecutedPercent { get; set; }
        public int WorkTaskState { get; set; }
    }
}
