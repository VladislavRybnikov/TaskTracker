using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Messaging.Entities;

namespace TaskTracker.Messaging.Builders
{
    /// <summary>
    /// Builder interface for mail entities.
    /// </summary>
    public interface IMailBuilder
    {
        IMailBuilder AddSystemPart(SystemMailEntity systemPart);
        IMailBuilder AddFromName(string fromName);
        IMailBuilder AddFromMail(string fromMail);
        IMailBuilder AddToName(string ToName);
        IMailBuilder AddToMail(string ToMail);
        IMailBuilder AddAttachment(string path);
        IMailBuilder AddAttacments(IEnumerable<string> attachments);
        IMailBuilder AddAttacments(params string[] attachments);
        IMailBuilder AddText(string text);
        IMailBuilder AddHtml(string html);
        IMailBuilder AddSubject(string subject);
        MailEntity Build();
        IMailBuilder Clear();
    }
}
