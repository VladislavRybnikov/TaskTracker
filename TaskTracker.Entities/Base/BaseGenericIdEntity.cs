using System;
using System.Collections.Generic;
using System.Text;

namespace TaskTracker.Entities.Base
{
    public abstract class BaseGenericIdEntity<TId>
    {
        public TId Id { get; set; }
    }
}
