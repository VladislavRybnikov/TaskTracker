using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using TaskTracker.Mapping.Messaging;
using TaskTracker.Messaging.Entities;
using TaskTracker.UnitTests.Builders;

namespace TaskTracker.UnitTests.Mapping
{
    public class MailEntityToMailMessageMapperTest
    {
        public TestMailBuilder builder = new TestMailBuilder();
        public MailEntityToMailMessageMapper mapper 
            = new MailEntityToMailMessageMapper();

        [Test]
        [Category("Mapping")]
        public void IsMailMessageMappedToMailEntity()
        {
            var mailMessage = builder.BuildMailMessage();

            var mappedMailEntity = mapper.Map(mailMessage);

            Assert.Multiple(
                () =>
                {
                    Assert.AreEqual(mappedMailEntity.From, builder.TestFrom);
                    Assert.AreEqual(mappedMailEntity.To, builder.TestTo);
                    Assert.AreEqual(mappedMailEntity.Data.Text, builder.TestBody);
                });
        }

        [Test]
        [Category("Mapping")]
        public void IsMailEntityMappedToMailMessage()
        {
            var mailEntity = builder.BuildMailEntity();

            var mappedMailEntity = mapper.Map(mailEntity);

            Assert.Multiple(
                () =>
                {
                    Assert.AreEqual(mappedMailEntity.From.Address,
                        builder.TestFrom);
                    Assert.AreEqual(mappedMailEntity.To[0].Address,
                        builder.TestTo);
                    Assert.AreEqual(mappedMailEntity.Body, builder.TestBody);
                });
        }

        [Test]
        [Category("Mapping")]
        public void IsMailEntityRangeMappedToMailMessageRange()
        {
            var mailEntities = new List<MailEntity>
            {
                builder.BuildMailEntity(),
                builder.BuildMailEntity("testFrom1@mail.com", "testFromName1"),
                builder.BuildMailEntity("testFrom2@mail.com", "testFromName2")
            };

            var mappedMailMessages = mapper.Map(mailEntities).ToList();

            Assert.AreEqual(mappedMailMessages.Count(), mailEntities.Count());

            for (int i = 0; i < mappedMailMessages.Count(); i++)
            {
                Assert.Multiple(
                    () =>
                    {
                        Assert.AreEqual(mappedMailMessages[i].From.Address,
                            mailEntities[i].From);
                        Assert.AreEqual(mappedMailMessages[i].From.DisplayName,
                            mailEntities[i].FromName);
                    });
            }
        }

        [Test]
        [Category("Mapping")]
        public void IsMailMessageRangeMappedToMailEntityRange()
        {
            var mailMessages = new List<MailMessage>
            {
                builder.BuildMailMessage(),
                builder.BuildMailMessage("testFrom1@mail.com", "testFromName1"),
                builder.BuildMailMessage("testFrom2@mail.com", "testFromName2")
            };

            var mappedMailEntities = mapper.Map(mailMessages).ToList();

            Assert.AreEqual(mappedMailEntities.Count(), mailMessages.Count());

            for (int i = 0; i < mappedMailEntities.Count(); i++)
            {
                Assert.Multiple(
                    () =>
                    {
                        Assert.AreEqual(mappedMailEntities[i].From,
                            mailMessages[i].From.Address);
                        Assert.AreEqual(mappedMailEntities[i].FromName,
                            mailMessages[i].From.DisplayName);
                    });
            }
        }
    }
}
