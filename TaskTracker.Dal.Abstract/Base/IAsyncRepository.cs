using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Entities.Base;

namespace TaskTracker.Dal.Abstract.Base
{
    public interface IAsyncRepository<TEntity, TKey> 
        where TEntity : BaseGenericIdEntity<TKey>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetAllAsync(ISpecification<TEntity> 
            specification);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> 
            criteria);

        Task<TEntity> GetByIdAsync(TKey id);
        Task<TEntity> FirstAsync(ISpecification<TEntity> specification);
        Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>>
            criteria);
    }
}
