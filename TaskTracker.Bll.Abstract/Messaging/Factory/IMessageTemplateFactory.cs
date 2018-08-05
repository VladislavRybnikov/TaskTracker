using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Bll.Abstract.Messaging.Template;
using TaskTracker.Common.Enums;
using TaskTracker.Messaging.Entities;

namespace TaskTracker.Bll.Abstract.Messaging.Factory
{
    /// <summary>
    /// Base interface for message template factory.
    /// </summary>
    public interface IMessageTemplateFactory
    {
        IMessageTemplate GetMessageTemplate(MessageTemplateType type, object additional);
    }
}
