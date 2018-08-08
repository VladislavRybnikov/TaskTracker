using System;
using System.Collections.Generic;
using System.Text;

namespace TaskTracker.Common.Configuration.Smtp
{
    public interface ISmtpConfiguration
    {
        string SmtpProvider { get; set; }
        int Port { get; set; }
        bool EnableSsl { get; set; }
        string MailAddress { get; set; }
        string Password { get; set; }
    }
}
