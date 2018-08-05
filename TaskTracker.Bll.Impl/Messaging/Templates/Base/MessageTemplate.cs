using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Bll.Abstract.Messaging.Template;
using TaskTracker.Common.Enums;
using TaskTracker.Messaging.Builders;
using TaskTracker.Messaging.Entities;

namespace TaskTracker.Bll.Impl.Messaging.Templates.Base
{
    public abstract class MessageTemplate : IMessageTemplate
    {
        protected readonly IMailBuilder _builder;

        public MessageTemplate(IMailBuilder builder)
        {
            _builder = builder;
        }

        public abstract MessageTemplateType MessageType { get; }

        public abstract MailEntity GetMail(SystemMailEntity systemMail,
            object additionalTemplateData);

        protected abstract void SetAdditionalTemplateData
            (object additionalTemplateData);
    }
}
