using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Messaging.Entities;

namespace TaskTracker.Messaging.Builders
{
    public class MailBuilder : IMailBuilder
    {
        private MailEntity _mail;

        public MailEntity Mail => _mail;

        public MailBuilder()
        {
            _mail = new MailEntity();
        }

        public void AddAttachment(string path)
        {
            _mail.Data.Attachments.Add(path);
        }

        public void AddAttacments(IEnumerable<string> attachments)
        {
            _mail.Data.Attachments.AddRange(attachments);
        }

        public void AddAttacments(params string[] attachments)
        {
            AddAttacments(attachments);
        }

        public void AddFromMail(string fromMail)
        {
            _mail.From = fromMail;
        }

        public void AddFromName(string fromName)
        {
            _mail.FromName = fromName;
        }

        public void AddHtml(string html)
        {
            _mail.Data.IsHtml = true;
            _mail.Data.Text = html;
        }

        public void AddSubject(string subject)
        {
            _mail.Data.Subject = subject;
        }

        public void AddText(string text)
        {
            _mail.Data.IsHtml = false;
            _mail.Data.Text = text;
        }

        public void AddToMail(string toMail)
        {
            _mail.To = toMail;
        }

        public void AddToName(string toName)
        {
            _mail.ToName = toName;
        }

        public void AddSystemPart(SystemMailEntity systemPart)
        {
            _mail.From = systemPart.From;
            _mail.FromName = systemPart.FromName;
            _mail.To = systemPart.To;
            _mail.ToName = systemPart.ToName;
        }

        public void Clear()
        {
            _mail = new MailEntity();
        }
    }
}
