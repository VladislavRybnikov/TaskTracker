using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Common.Enums;
using TaskTracker.Messaging.Entities;

namespace TaskTracker.Bll.Abstract.Messaging.Notifications
{
    public interface ITemplateSender
    {
        void Send(MessageTemplateType type, SystemMailEntity systemMail);
        void SendAsync(MessageTemplateType type, SystemMailEntity systemMail);
    }
}
