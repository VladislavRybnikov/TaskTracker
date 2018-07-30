﻿using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Bll.Abstract.Messaging.Template;
using TaskTracker.Common.Enums;
using TaskTracker.Messaging.Entities;

namespace TaskTracker.Bll.Impl.Messaging.Templates
{
    public class TaskStartTemplate : IMessageTemplate
    {
        public MessageTemplateType MessageType 
            => MessageTemplateType.TaskStartNotification;

        public MailEntity GetMail(SystemMailEntity systemMail)
        {
            //TODO: Create html based template for confirm registration.
            throw new NotImplementedException();
        }
    }
}