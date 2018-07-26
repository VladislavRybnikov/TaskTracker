using System;
using System.Collections.Generic;
using System.Text;

namespace TaskTracker.Messaging.Entities
{
    /// <summary>
    /// Base mail class. Has only system information. 
    /// </summary>
    public class SystemMailEntity
    {
        public string From { get; set; }
        public string FromName { get; set; }
        public string To { get; set; }
        public string ToName { get; set; }
    }
}
