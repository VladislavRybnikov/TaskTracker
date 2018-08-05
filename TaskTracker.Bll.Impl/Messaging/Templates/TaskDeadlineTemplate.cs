using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Bll.Abstract.Messaging.Template;
using TaskTracker.Bll.Impl.Messaging.Templates.Base;
using TaskTracker.Common.Enums;
using TaskTracker.Dto;
using TaskTracker.Messaging.Builders;
using TaskTracker.Messaging.Entities;

namespace TaskTracker.Bll.Impl.Messaging.Templates
{
    public class TaskDeadlineTemplate : MessageTemplate, IMessageTemplate
    {
        private string taskName;
        private string taskDeadline;
        private string timeLeft;

        public TaskDeadlineTemplate(IMailBuilder builder) : base(builder)
        {
        }

        public override MessageTemplateType MessageType 
            => MessageTemplateType.TaskDeadlineNotification;

        protected override void SetAdditionalTemplateData
            (object additionalTemplateData)
        {
            // Cast additionalTemplateData object to allowed type 
            // and get data from it.
            // Throw new ArgumentException() if type are not allowed in current context. 
            switch (additionalTemplateData)
            {
                case WorkTaskDto workTask:
                    taskName = workTask.Name;
                    taskDeadline = workTask.Deadline.ToString();
                    timeLeft = (DateTime.Now - workTask.Deadline).ToString();
                    break;

                case Tuple<string, string, string> tuple:
                    taskName = tuple.Item1;
                    taskDeadline = tuple.Item2;
                    timeLeft = tuple.Item3;
                    break;

                default:
                    throw new ArgumentException("Wrong argument type.");
            }
        }

        public override MailEntity GetMail(SystemMailEntity systemMail, object additionalTemplateData)
        {
            StringBuilder htmlBuilder = new StringBuilder();
            WorkTaskDto workTaskDto = additionalTemplateData as WorkTaskDto;

            SetAdditionalTemplateData(additionalTemplateData);

            var subject = "TaskTracker Task Deadline.";

            var html = htmlBuilder.Append
                (@"<!DOCTYPE html>
                    <html>
                        <head>
                             <style> ")
                    .Append(TemplateStyleHolder.DefaultStyle)
                    .Append(@"</style>
                        </head>
                        <body>
                            <div class= 'message-header'>
                                <div class='title'>
                                    TaskTracker
                                </div>
                            </div>
                            <div class='message-content'>
                                <div>
                                    <h3>TaskTracker Team.</h3>
                                     <hr>")
                    .Append($"Hello {systemMail.ToName}.<br>")
                    .Append(@"Welcome to TaskTracker!<br>
                    Hurry up!!! <br>
                    For deadline for your task ")
                    .Append($"({taskName}) will be on {taskDeadline}." +
                    $"You have only: {timeLeft} hr.")
                    .Append(@")
                                </div>
                                <div class='base-button-container'>
                                    <a href='#...' class='base-button'>
                                        Go To Task!</a>
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
                .AddSubject(subject)
                .AddHtml(html)
                .Build();
        }
    }
}
