using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Bll.Abstract.Messaging.Factory;
using TaskTracker.Bll.Abstract.Messaging.Notifications;
using TaskTracker.Common.Enums;
using TaskTracker.Common.Results;
using TaskTracker.Messaging.Base;
using TaskTracker.Messaging.Entities;

namespace TaskTracker.Bll.Impl.Messaging
{
    public class TemplateSender : ITemplateSender
    {
        private readonly IMailSender _mailSender;
        private readonly IMessageTemplateFactory _factory;

        public TemplateSender(IMessageTemplateFactory messageFactory,
            IMailSender sender)
        {
            _mailSender = sender;
            _factory = messageFactory;
        }

 
        private Result GetMailResult
            (
            MessageTemplateType type,
            SystemMailEntity systemMail,
            object additionalData,
            out MailEntity mail
            )
        {
            mail = null;

            var result = new Result();

            var template = _factory.GetMessageTemplate(type, additionalData);

            if (template == null)
            {
                result.Message = "Wrong tepmlate type.";
                return result;
            }

            try
            {
                mail = template.GetMail(systemMail, additionalData);
            }
            catch (ArgumentException)
            {
                result.Message = "Can'nt build template. " +
                    "Additional data has wrong type.";
                return result;
            }

            result.Success = true;

            return result;
        }
        

        public Result Send(MessageTemplateType type,
            SystemMailEntity systemMail,
            object additionalData)
        {
            var result = GetMailResult(type, systemMail,
                additionalData, out MailEntity mail);

            if (result.Success == false)
            {
                return result;
            }

            using (_mailSender)
            {
                _mailSender.SendMail(mail);
            }

            result = new Result(true, 
                $"Message sended to user({systemMail.To}).");

            return result;
        }

        public async Task<Result> SendAsync(MessageTemplateType type,
            SystemMailEntity systemMail, object additionalData)
        {
            var result = GetMailResult(type, systemMail,
                additionalData, out MailEntity mail);

            if (result.Success == false)
            {
                return result;
            }

            using (_mailSender)
            {
                await _mailSender.SendMailAsync(mail);
            }

            result = new Result(true,
                $"Message sended to user({systemMail.To}).");

            return result;
        }
    }
}
