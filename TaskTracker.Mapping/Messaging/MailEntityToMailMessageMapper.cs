using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using TaskTracker.Messaging.Entities;

namespace TaskTracker.Mapping.Messaging
{
    public class MailEntityToMailMessageMapper
        : IMailEntityToMailMessageMapper
    {
        public MailEntity Map(MailMessage from)
        {
            throw new NotImplementedException();
        }

        public MailMessage Map(MailEntity from)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MailEntity> Map(IEnumerable<MailMessage> from)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MailMessage> Map(IEnumerable<MailEntity> from)
        {
            throw new NotImplementedException();
        }
    }
}
