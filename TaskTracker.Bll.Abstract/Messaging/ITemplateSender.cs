using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Common.Enums;
using TaskTracker.Common.Results;
using TaskTracker.Messaging.Entities;

namespace TaskTracker.Bll.Abstract.Messaging.Notifications
{
    /// <summary>
    /// Template sender for web api.
    /// </summary>
    public interface ITemplateSender
    {
        Result Send(MessageTemplateType type, SystemMailEntity systemMail,
            object additionalData);
        Task<Result> SendAsync(MessageTemplateType type,
            SystemMailEntity systemMail, object additionalData);
    }
}
