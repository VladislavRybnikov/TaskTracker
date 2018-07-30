using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Bll.Abstract.Messaging.Factory;
using TaskTracker.Bll.Abstract.Messaging.Template;
using TaskTracker.Bll.Impl.Messaging.Templates;
using TaskTracker.Common.Enums;
using TaskTracker.Messaging.Builders;
using TaskTracker.Messaging.Entities;

namespace TaskTracker.Bll.Impl.Messaging.Factory
{
    /// <summary>
    /// Factory that return mail entites from template based on MessageTemplateType.
    /// </summary>
    public class MessageFactory : IMessageTemplateFactory
    {
        private static List<IMessageTemplate> _messageTemplates;
        private static IMailBuilder _builder;

        public MessageFactory(IMailBuilder builder)
        {
            _builder = builder;
            Initialize();
        }

        private static void Initialize()
        {
            if (_messageTemplates == null)
            {
                _messageTemplates = new List<IMessageTemplate>
                {
                    new RegistrationTemplate(_builder),
                    new TaskDeadlineTemplate(),
                    new TaskStartTemplate()
                };
            }
        }

        /// <summary>
        /// Return message template by type.
        /// </summary>
        /// <param name="type">Template type.</param>
        /// <returns></returns>
        public IMessageTemplate GetMessageTemplate(MessageTemplateType type)
        {
            return _messageTemplates
                .Find(x => x.MessageType == type);
        }
    }
}
