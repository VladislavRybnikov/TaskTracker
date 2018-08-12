using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TaskTracker.Entities.Base;

namespace TaskTracker.Dal.Abstract.Base
{
    public interface IRepository<TEntity, TKey> 
        where TEntity : BaseGenericIdEntity<TKey>
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll(ISpecification<TEntity> specification);
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> criteria);

        TEntity GetById(TKey id);
        TEntity First(ISpecification<TEntity> specification);
        TEntity First(Expression<Func<TEntity, bool>> criteria);

    }
}
