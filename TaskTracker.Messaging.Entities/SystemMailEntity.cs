using System;
using System.Collections.Generic;
using System.Text;

namespace TaskTracker.Messaging.Entities
{
    public class SystemMailEntity
    {
        public string From { get; set; }
        public string FromName { get; set; }
        public string To { get; set; }
        public string ToName { get; set; }
    }
}
