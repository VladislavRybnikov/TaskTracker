using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Messaging.Entities;

namespace TaskTracker.Messaging.Builders
{
    /// <summary>
    /// Base mail entity builder implementation.
    /// </summary>
    public class MailBuilder : IMailBuilder
    {

        public MailEntity Mail { get; private set; }

        public MailBuilder()
        {
            Mail = new MailEntity();
        }

        public void AddAttachment(string path)
        {
            Mail.Data.Attachments.Add(path);
        }

        public void AddAttacments(IEnumerable<string> attachments)
        {
            Mail.Data.Attachments.AddRange(attachments);
        }

        public void AddAttacments(params string[] attachments)
        {
            AddAttacments(attachments);
        }

        public void AddFromMail(string fromMail)
        {
            Mail.From = fromMail;
        }

        public void AddFromName(string fromName)
        {
            Mail.FromName = fromName;
        }

        public void AddHtml(string html)
        {
            Mail.Data.IsHtml = true;
            Mail.Data.Text = html;
        }

        public void AddSubject(string subject)
        {
            Mail.Data.Subject = subject;
        }

        public void AddText(string text)
        {
            Mail.Data.IsHtml = false;
            Mail.Data.Text = text;
        }

        public void AddToMail(string toMail)
        {
            Mail.To = toMail;
        }

        public void AddToName(string toName)
        {
            Mail.ToName = toName;
        }

        public void AddSystemPart(SystemMailEntity systemPart)
        {
            Mail.From = systemPart.From;
            Mail.FromName = systemPart.FromName;
            Mail.To = systemPart.To;
            Mail.ToName = systemPart.ToName;
        }

        public void Clear()
        {
            Mail = new MailEntity();
        }
    }
}
