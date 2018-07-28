using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using TaskTracker.Mapping.Helpers;
using TaskTracker.Messaging.Entities;

namespace TaskTracker.Mapping.Messaging
{
    /// <summary>
    /// Mapping class for SMTP mail sending.
    /// </summary>
    public class MailEntityToMailMessageMapper
        : IMailEntityToMailMessageMapper
    {
        public MailEntity Map(MailMessage from)
        {
            MailEntity mail = new MailEntity
            {
                From = from.From.Address,
                FromName = from.From.DisplayName,
                To = from.To[0].Address,
                ToName = from.To[0].DisplayName
            };

            mail.Data.IsHtml = from.IsBodyHtml;
            mail.Data.Subject = from.Subject;
            mail.Data.Text = from.Body;

            return mail;
        }

        public MailMessage Map(MailEntity from)
        {
            MailMessage mail = new MailMessage
                (
                    new MailAddress(from.From, from.FromName),
                    new MailAddress(from.To, from.ToName)
                );

            mail.IsBodyHtml = from.Data.IsHtml;
            mail.Body = from.Data.Text;
            mail.Subject = from.Data.Subject;

            //Add attachments to smtp mail message
            from.Data.Attachments
                .ForEach(x => mail.Attachments.Add(new Attachment(x)));

            return mail;
        }

        public IEnumerable<MailEntity> Map(IEnumerable<MailMessage> from) 
            => MapperHelper.TransformRange(from, Map);

        public IEnumerable<MailMessage> Map(IEnumerable<MailEntity> from) 
            => MapperHelper.TransformRange(from, Map);

    }
}
