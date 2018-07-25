using System;
using System.Collections.Generic;
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

        Task<TEntity> GetByIdAsync(TKey id);
        Task<TEntity> FirstAsync(ISpecification<TEntity> specification);
    }
}
