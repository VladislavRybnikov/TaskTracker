using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Bll.Abstract.Messaging.Template;
using TaskTracker.Common.Enums;
using TaskTracker.Messaging.Entities;

namespace TaskTracker.Bll.Impl.Messaging.Templates
{
    public class TaskDeadlineTemplate : IMessageTemplate
    {
        public MessageTemplateType MessageType 
            => MessageTemplateType.TaskDeadlineNotification;

        public MailEntity GetMail(SystemMailEntity systemMail)
        {
            //TODO: Create html based template for confirm registration.
            throw new NotImplementedException();
        }
    }
}
