using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Common.Enums;
using TaskTracker.Messaging.Entities;

namespace TaskTracker.Messaging.Base
{
    /// <summary>
    /// Provides basic logic for sending mail.
    /// </summary>
    public interface IMailSender : IDisposable
    {
        void SendMail(MailEntity mail);
        void SendMailAsync(MailEntity mail);
    }
}
