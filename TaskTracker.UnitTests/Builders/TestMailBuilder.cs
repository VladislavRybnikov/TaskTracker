using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using TaskTracker.Messaging.Builders;
using TaskTracker.Messaging.Entities;

namespace TaskTracker.UnitTests.Builders
{
    public class TestMailBuilder
    {
        private MailMessage _mailMessage;
        private MailEntity _mailEntity;

        private const bool _isHtmlTest = false;
        private const string _testBody = "TestBody";
        private const string _testSubject = "TestSubject";
        private const string _testFrom = "testFrom@mail.com";
        private const string _testFromName = "TestFromName";
        private const string _testTo = "testTo@mail.com";
        private const string _testToName = "TestToName";

        public bool IsHtmlTest => _isHtmlTest;
        public string TestBody => _testBody;
        public string TestSubject => _testSubject;
        public string TestFrom => _testFrom;
        public string TestFromName => _testFromName;
        public string TestTo => _testTo;
        public string TestToName => _testToName;

        public TestMailBuilder() 
        {
        }

        public MailMessage BuildMailMessage
            (
            string from = _testFrom, 
            string fromName = _testFromName, 
            string to = _testTo, 
            string toName = _testToName, 
            string subject = _testSubject,
            string body = _testBody,
            bool isHtml = _isHtmlTest
            )
        {
            _mailMessage = new MailMessage
                (
                new MailAddress(from, fromName),
                new MailAddress(to, toName)
                )
            {
                IsBodyHtml = isHtml,
                Body = body,
                Subject = subject
            };

            return _mailMessage;
        }

        public SystemMailEntity BuildSystemMailEntity
            (
            string from = _testFrom,
            string fromName = _testFromName,
            string to = _testTo,
            string toName = _testToName
            )
        {
            return new SystemMailEntity
            {
                From = from,
                FromName = fromName,
                To = to,
                ToName = toName
            };
        }

        public MailEntity BuildMailEntity
            (
            string from = _testFrom,
            string fromName = _testFromName,
            string to = _testTo,
            string toName = _testToName,
            string subject = _testSubject,
            string body = _testBody,
            bool isHtml = _isHtmlTest
            )
        {
            _mailEntity = new MailBuilder()
                .AddSystemPart(new SystemMailEntity
                {
                    From = from,
                    FromName = fromName,
                    To = to,
                    ToName = toName
                })
                .AddText(body)
                .AddSubject(subject)
                .Build();

            return _mailEntity;
        }
        
    }
}
