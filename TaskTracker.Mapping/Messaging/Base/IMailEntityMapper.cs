using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Mapping.Base;
using TaskTracker.Messaging.Entities;

namespace TaskTracker.Mapping.Messaging.Base
{
    public interface IMailEntityMapper<TEntity> : IMapper<MailEntity, TEntity>
    {
    }
}
