using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Entities.Base;

namespace TaskTracker.Entities
{
    public class UserContacts : BaseIntIdEntity
    {
        public Location Location { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set;}
    }
}
