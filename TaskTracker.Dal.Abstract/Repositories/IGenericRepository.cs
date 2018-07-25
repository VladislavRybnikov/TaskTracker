using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Dal.Abstract.Base;
using TaskTracker.Entities.Base;

namespace TaskTracker.Dal.Abstract.Repositories
{
    public interface IGenericRepository<TEntity> : IRepository<TEntity, int>,
        IAsyncRepository<TEntity, int> where TEntity : BaseIntIdEntity
    {
    }
}
