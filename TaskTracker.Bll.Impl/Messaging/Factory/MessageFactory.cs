using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Bll.Abstract.Messaging.Factory;
using TaskTracker.Bll.Abstract.Messaging.Template;
using TaskTracker.Bll.Impl.Messaging.Templates;
using TaskTracker.Common.Enums;
using TaskTracker.Messaging.Entities;

namespace TaskTracker.Bll.Impl.Messaging.Factory
{
    /// <summary>
    /// Factory that return mail entites from template based on MessageTemplateType.
    /// </summary>
    public class MessageFactory : IMessageFactory
    {
        private static List<IMessageTemplate> _messageTemplates;

        static MessageFactory()
        {
            Initialize();
        }

        private static void Initialize()
        {
            _messageTemplates = new List<IMessageTemplate>
            {
                new RegistrationConfirmationTemplate(),
                new TaskDeadlineTemplate(),
                new TaskStartTemplate()
            };
        }

        /// <summary>
        /// Return MailEntity with content from template.
        /// </summary>
        /// <param name="type">Template type.</param>
        /// <param name="systemMail">System template part.</param>
        /// <returns></returns>
        public MailEntity GetMessageTemplate(MessageTemplateType type,
            SystemMailEntity systemMail)
        {
            return _messageTemplates
                .Find(x => x.MessageType == type)
                .GetMail(systemMail);
        }
    }
}
