using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Bll.Abstract.Messaging.Factory;
using TaskTracker.Bll.Abstract.Messaging.Notifications;
using TaskTracker.Common.Enums;
using TaskTracker.Messaging.Base;
using TaskTracker.Messaging.Entities;

namespace TaskTracker.Bll.Impl.Messaging
{
    public class TemplateSender : ITemplateSender
    {
        private readonly IMailSender _mailSender;
        private readonly IMessageFactory _factory;

        public TemplateSender(IMessageFactory messageFactory, IMailSender sender)
        {
            _mailSender = sender;
            _factory = messageFactory;
        }

        public void Send(MessageTemplateType type, SystemMailEntity systemMail)
        {
            var mail = _factory.GetMessageTemplate(type, systemMail);

            using (_mailSender)
            {
                _mailSender.SendMail(mail);
            }
        }

        public async void SendAsync(MessageTemplateType type,
            SystemMailEntity systemMail)
        {
            var mail = _factory.GetMessageTemplate(type, systemMail);

            using (_mailSender)
            {
                await _mailSender.SendMailAsync(mail);
            }
        }
    }
}
