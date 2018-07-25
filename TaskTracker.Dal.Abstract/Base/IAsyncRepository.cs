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
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);

        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetAllAsync(ISpecification<TEntity> 
            specification);

        Task<TEntity> GetById(TKey id);
        Task<TEntity> First(ISpecification<TEntity> specification);
    }
}
