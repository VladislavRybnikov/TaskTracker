using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Bll.Abstract.Messaging.Factory;
using TaskTracker.Bll.Abstract.Messaging.Notifications;
using TaskTracker.Bll.Impl.Messaging;
using TaskTracker.Bll.Impl.Messaging.Factory;
using TaskTracker.Common.Enums;
using TaskTracker.Messaging.Base;
using TaskTracker.Messaging.Builders;
using TaskTracker.Messaging.Entities;
using TaskTracker.UnitTests.Builders;

namespace TaskTracker.UnitTests.Bll.Messaging
{
    public class TemplateSenderTest
    {
        ITemplateSender TemplateSender => new TemplateSender
            (new MessageFactory(new MailBuilder()),
            new FakeMailSender());

        TestMailBuilder Builder => new TestMailBuilder();

        [Test]
        [Category("Messaging")]
        public void SendMustReturnBadResultOnWrongTypeAdditionalData()
        {
            object wrongData = string.Empty;
            var type = MessageTemplateType
                .TaskDeadlineNotification;
            var systemMailPart = Builder.BuildSystemMailEntity();

            var result = TemplateSender.Send
                (type,
                systemMailPart,
                wrongData);

            string returnedMessage = "Can'nt build template. " +
                    "Additional data has wrong type.";
            Assert.Multiple(() =>
            {
                Assert.False(result.Success);
                Assert.AreEqual(result.Message, returnedMessage);
            });
        }

        [Test]
        [Category("Messaging")]
        public void SendMesssageWithoutDataMustReturnSuccessfulResult()
        {
            var type = MessageTemplateType
                .RegistrationConfirm;
            var systemMailPart = Builder.BuildSystemMailEntity();

            var result = TemplateSender.Send
                (type, systemMailPart, null);
            TestContext.Out.WriteLine(result.Message);

            var returnedMessage = $"Message sended to user" +
                $"({systemMailPart.To}).";
            Assert.Multiple(() =>
            {
                Assert.True(result.Success);
                Assert.AreEqual(result.Message, returnedMessage);
            });
        }
    }

    #region Fake data

    // TODO: rewrite to moq
    public class FakeMailSender : IMailSender
    {
        public void Dispose()
        {
        }

        public void SendMail(MailEntity mail)
        {
            //fake
        }

        public Task SendMailAsync(MailEntity mail)
        { return Task.Run(() => { }); }
    } 
    #endregion
}
