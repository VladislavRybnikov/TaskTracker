using System;
using System.Collections.Generic;
using System.Text;

namespace TaskTracker.Entities.Base
{
    public abstract class BaseUser : BaseIntIdEntity
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Info { get; set; }
    }
}
