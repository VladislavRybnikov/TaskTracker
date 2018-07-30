using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Bll.Abstract.Messaging.Template;
using TaskTracker.Bll.Impl.Messaging.Templates.Base;
using TaskTracker.Common.Enums;
using TaskTracker.Messaging.Builders;
using TaskTracker.Messaging.Entities;

namespace TaskTracker.Bll.Impl.Messaging.Templates
{
    public class RegistrationTemplate : MessageTemplate, IMessageTemplate
    {
        public RegistrationTemplate(IMailBuilder builder) : base(builder) { }

        public override MessageTemplateType MessageType
            => MessageTemplateType.RegistrationConfirm;

        public override MailEntity GetMail(SystemMailEntity systemMail)
        {
            StringBuilder htmlBuilder = new StringBuilder();

            var html = htmlBuilder.Append
                (@"<!DOCTYPE html>
                    <html>
                        <head>
                             <style> ")
                .Append(TemplateStyleHolder.DefaultStyle)
                .Append(@"</style>
                        </head>
                        <body>
                            <div class= 'message - header'>
                                <div class='title'>
                                    TaskTracker
                                </div>
                            </div>
                            <div class='message-content'>
                                <div>
                                    <h3>TaskTracker Team.</h3>
                                     <hr>")
                 .Append($"Hello {systemMail.FromName}.<br>")
                 .Append(@"Welcome to TaskTracker!<br>
                    Thanks for your registration. 
                    Return to the site to update your information 
                    and start work eith your tasks!
                                </div>
                                <div class='base-button-container'>
                                    <a href='#...' class='base-button'>
                                        Go To TaskTracker!</a>
                                </div>
                            </div>
                            <div class='message-footer'>
                                <div class='text'>
                                    <h4>Contacts: </h4>
                                    Phone number: xxx-xxx-xxx<br>
                                    E-Mail: xxxx @mail.com
                            </div>
                        </div>
                    </body>
                </html>").ToString();

            return _builder
                .AddSystemPart(systemMail)
                .AddSubject("TaskTracker Registration.")
                .AddHtml(html)
                .Build();
        }

    }
}
