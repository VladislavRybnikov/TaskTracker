using System;
using System.Collections.Generic;
using System.Text;

namespace TaskTracker.Messaging.Entities
{
    public class MailEntity : SystemMailEntity
    {
        public DataMailEntity Data { get; }

        public MailEntity()
        {
            Data = new DataMailEntity();
        }
    }
}
