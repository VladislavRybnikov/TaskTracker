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
        private static List<IMessageTemplate> _data;
        private static IMailBuilder _builder;

        public MessageFactory(IMailBuilder builder)
        {
            _builder = builder;

            InitializeData();
        }

        private static void InitializeData()
        {
            if (_data == null)
            {
                _data = new List<IMessageTemplate>  
                {
                    new RegistrationTemplate(_builder),
                    new TaskDeadlineTemplate(_builder),
                    new TaskStartTemplate(_builder)
                };
            }
        }

        /// <summary>
        /// Return message template by type.
        /// </summary>
        /// <param name="type">Template type.</param>
        /// <returns></returns>
        public IMessageTemplate GetMessageTemplate(MessageTemplateType type,
            object additionalTemplateData)
        {
            return _data
                .Find(x => x.MessageType == type);
        }
    }
}
