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
    /// <summary>
    /// Provides methods for sending mail via smtp.
    /// Need to be disposed.
    /// </summary>
    public class SmtpMailSender : IMailSender
    {
        private bool _disposed = false;

        private readonly IMailEntityToMailMessageMapper _mapper;
        private SmtpClient _smtpClient;


        public SmtpMailSender(IMailEntityToMailMessageMapper mapper, 
            SmtpConfiguration config)
        {
            _mapper = mapper;
            InitializeSmtp(config);
        }

        //Initialize SmtpClient using SmtpConfiguration. 
        private void InitializeSmtp(SmtpConfiguration configuration)
        {
            SmtpClient smtpClient = new SmtpClient
                    (configuration.SmtpProvider)
            {
                Port = configuration.Port,
                Credentials = new NetworkCredential
                    (configuration.MailAddress, configuration.Password),
                EnableSsl = configuration.EnableSsl
            };
            _smtpClient = smtpClient;
        }

        /// <summary>
        /// Send mail via smtp connection synchronously.
        /// </summary>
        /// <param name="mail">Mail entity to send.</param>
        public void SendMail(MailEntity mail)
        {
            var smtpMail = _mapper.Map(mail);

            _smtpClient.Send(smtpMail);
        }

        /// <summary>
        ///  Send mail via smtp connection asynchronously.
        /// </summary>
        /// <param name="mail">Mail entity to send.</param>
        public async Task SendMailAsync(MailEntity mail)
        {
            var smtpMail = _mapper.Map(mail);

            await _smtpClient.SendMailAsync(smtpMail);
        }

        /// <summary>
        /// Sends QUIT message to SMTP, end TCP connection.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _smtpClient.Dispose();
                }
            }
            _disposed = true;
        }

        ~SmtpMailSender()
        {
            Dispose(false);
        }

    }
}
