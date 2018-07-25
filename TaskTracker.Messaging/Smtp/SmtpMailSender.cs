using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Common.Configuration.Smtp;
using TaskTracker.Common.Enums;
using TaskTracker.Mapping.Messaging;
using TaskTracker.Messaging.Base;
using TaskTracker.Messaging.Entities;

namespace TaskTracker.Messaging.Smtp
{
    public class SmtpMailSender : IMailSender
    {
        private readonly IMailEntityToMailMessageMapper _mapper;
        private readonly SmtpConfiguration _configuration;

        public SmtpMailSender(IMailEntityToMailMessageMapper mapper, 
            SmtpConfiguration config)
        {
            _mapper = mapper;
            _configuration = config;
        }

        public void SendMail(MailEntity mail) 
            => GetSmtpClient().Send(_mapper.Map(mail));

        public async void SendMailAsync(MailEntity mail) 
            => await Task.Run(() => SendMail(mail));

        private SmtpClient GetSmtpClient()
        {
            SmtpClient smtpClient = new SmtpClient
                (_configuration.SmtpProvider)
            {
                Port = _configuration.Port,
                Credentials = new NetworkCredential
                (_configuration.MailAddress, _configuration.Password),
                EnableSsl = _configuration.EnableSsl
            };

            return smtpClient;
        }

    }
}
