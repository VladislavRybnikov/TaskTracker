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
    public class TaskStartTemplate : MessageTemplate, IMessageTemplate
    {
        private string taskName;
        private string taskStart;
        private string taskDeadline;

        public TaskStartTemplate(IMailBuilder builder) : base(builder)
        {
        }

        public override MessageTemplateType MessageType 
            => MessageTemplateType.TaskStartNotification;

        public override MailEntity GetMail(SystemMailEntity systemMail,
            object additionalTemplateData)
        {
            throw new NotImplementedException();
        }

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
                    taskStart = workTask.CreationDate.ToString();
                    taskDeadline = workTask.Deadline.ToString();
                    break;

                case Tuple<string, string, string> tuple:
                    taskName = tuple.Item1;
                    taskStart = tuple.Item2;
                    taskDeadline = tuple.Item3;
                    break;

                default:
                    throw new ArgumentException("Wrong argument type.");
            }
        }
    }
}
