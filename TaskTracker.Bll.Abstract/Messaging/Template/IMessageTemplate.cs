using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Common.Enums;
using TaskTracker.Messaging.Entities;

namespace TaskTracker.Bll.Abstract.Messaging.Template
{
    public interface IMessageTemplate
    {
        MessageTemplateType MessageType { get; }
        MailEntity GetMail(SystemMailEntity systemMail);
    }
}
