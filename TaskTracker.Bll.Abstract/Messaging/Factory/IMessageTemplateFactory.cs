﻿using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Bll.Abstract.Messaging.Template;
using TaskTracker.Common.Enums;
using TaskTracker.Messaging.Entities;

namespace TaskTracker.Bll.Abstract.Messaging.Factory
{
    public interface IMessageTemplateFactory
    {
        IMessageTemplate GetMessageTemplate(MessageTemplateType type);
    }
}