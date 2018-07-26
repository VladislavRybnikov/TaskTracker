using System;
using System.Collections.Generic;
using System.Text;

namespace TaskTracker.Messaging.Entities
{
    /// <summary>
    /// Mail class wich aggregate system and data part of mail.
    /// </summary>
    public class MailEntity : SystemMailEntity
    {
        public DataMailEntity Data { get; }

        public MailEntity()
        {
            Data = new DataMailEntity();
        }
    }
}
