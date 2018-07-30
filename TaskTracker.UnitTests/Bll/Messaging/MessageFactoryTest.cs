﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Bll.Impl.Messaging.Factory;
using TaskTracker.Bll.Impl.Messaging.Templates;
using TaskTracker.Common.Enums;
using TaskTracker.Messaging.Builders;
using TaskTracker.Messaging.Entities;

namespace TaskTracker.UnitTests.Bll.Messaging
{
    public class MessageFactoryTest
    {
        private readonly MessageFactory _factory = new MessageFactory(new MailBuilder());

        [Test]
        [Category("Messaging")]
        public void ReturnTaskStartTemplateByMessageTemplateType()
        {
            var enumValue
                = MessageTemplateType.RegistrationConfirm;

            var template = _factory.GetMessageTemplate(enumValue);
            var templateType = template.GetType();
            TestContext.Out.WriteLine(template.GetMail
                (new SystemMailEntity { ToName = "TEST"}).Data.Text);

            Assert.AreEqual(templateType, typeof(RegistrationTemplate));
        }
    }
}
