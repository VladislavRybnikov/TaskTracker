using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using TaskTracker.Mapping.Messaging.Base;

namespace TaskTracker.Mapping.Messaging
{
    public interface IMailEntityToMailMessageMapper 
        : IMailEntityMapper<MailMessage>
    {
    }
}
