using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Messaging.Entities;

namespace TaskTracker.Messaging.Builders
{
    /// <summary>
    /// Base mail entity builder implementation.`
    /// </summary>
    public class MailBuilder : IMailBuilder
    {
        private MailEntity _mail;

        public MailBuilder()
        {
            _mail = new MailEntity();
        }

        public IMailBuilder AddAttachment(string path)
        {
            _mail.Data.Attachments.Add(path);
            return this;
        }

        public IMailBuilder AddAttacments(IEnumerable<string> attachments)
        {
            _mail.Data.Attachments.AddRange(attachments);
            return this;
        }

        public IMailBuilder AddFromMail(string fromMail)
        {
            _mail.From = fromMail;
            return this;
        }

        public IMailBuilder AddFromName(string fromName)
        {
            _mail.FromName = fromName;
            return this;
        }

        public IMailBuilder AddHtml(string html)
        {
            _mail.Data.IsHtml = true;
            _mail.Data.Text = html;
            return this;
        }

        public IMailBuilder AddSubject(string subject)
        {
            _mail.Data.Subject = subject;
            return this;
        }

        public IMailBuilder AddText(string text)
        {
            _mail.Data.IsHtml = false;
            _mail.Data.Text = text;
            return this;
        }

        public IMailBuilder AddToMail(string toMail)
        {
            _mail.To = toMail;
            return this;
        }

        public IMailBuilder AddToName(string toName)
        {
            _mail.ToName = toName;
            return this;
        }

        public IMailBuilder AddSystemPart(SystemMailEntity systemPart)
        {
            _mail.From = systemPart.From;
            _mail.FromName = systemPart.FromName;
            _mail.To = systemPart.To;
            _mail.ToName = systemPart.ToName;
            return this;
        }

        public MailEntity Build()
        {
            return _mail;
        }

        public IMailBuilder Clear()
        {
            _mail = new MailEntity();
            return this;
        }

        public IMailBuilder AddAttacments(params string[] attachments)
        {
            return AddAttacments(attachments);
        }
    }
}
