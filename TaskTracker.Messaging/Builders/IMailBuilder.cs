using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Messaging.Entities;

namespace TaskTracker.Messaging.Builders
{
    public interface IMailBuilder
    {
        MailEntity Mail { get; }

        void AddSystemPart(SystemMailEntity systemPart);
        void AddFromName(string fromName);
        void AddFromMail(string fromMail);
        void AddToName(string ToName);
        void AddToMail(string ToMail);
        void AddAttachment(string path);
        void AddAttacments(IEnumerable<string> attachments);
        void AddAttacments(params string[] attachments);
        void AddText(string text);
        void AddHtml(string html);
        void AddSubject(string subject);
        void Clear();
    }
}
