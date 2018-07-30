using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Entities.Base;

namespace TaskTracker.Entities
{
    public class Location : BaseIntIdEntity
    {
        public string Country { get; set; }
        public string City { get; set; }
    }
}
