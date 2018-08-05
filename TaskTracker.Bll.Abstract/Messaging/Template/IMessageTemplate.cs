using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Common.Enums;
using TaskTracker.Messaging.Entities;

namespace TaskTracker.Bll.Abstract.Messaging.Template
{
    /// <summary>
    /// Message template interface.
    /// </summary>
    public interface IMessageTemplate
    {
        MessageTemplateType MessageType { get; }
        MailEntity GetMail(SystemMailEntity systemMail, 
            object additionalTemplateData);
    }
}
