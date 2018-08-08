using System;
using System.Collections.Generic;
using System.Text;

namespace TaskTracker.Common.Configuration.Smtp
{
    public class SmtpConfiguration : ISmtpConfiguration
    {
        public string SmtpProvider { get; set; }
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
        public string MailAddress { get; set; }
        public string Password { get; set; }
    }
}
