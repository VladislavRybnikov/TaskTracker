using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Bll.Impl.Messaging.Factory;
using TaskTracker.Bll.Impl.Messaging.Templates;
using TaskTracker.Common.Enums;
using TaskTracker.Messaging.Entities;

namespace TaskTracker.UnitTests.Bll.Messaging
{
    public class MessageFactoryTest
    {
        private readonly MessageFactory _factory = new MessageFactory();

        [Test]
        [Category("Messaging")]
        public void ReturnTaskStartTemplateByMessageTemplateType()
        {
            var enumValue
                = MessageTemplateType.TaskStartNotification;

            var template = _factory.GetMessageTemplate(enumValue);
            var templateType = template.GetType();

            Assert.AreEqual(templateType, typeof(TaskStartTemplate));
        }
    }
}
