using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Common.Enums;

namespace TaskTracker.Bll.Abstract.Messaging.Notifications
{
    public interface IMailNotificator
    {
        void Notificate(NotificationType type);
    }
}
