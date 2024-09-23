using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IUniversity.Core.Repository.Interface.Base
{
    public interface IBaseRepository<TEntity, TContext>
        where TEntity : class
        where TContext : DbContext
    {
        Task<List<TEntity>> GetAll();
        Task<TEntity> Get(Guid id);
        Task<TEntity> Get(int id);
        Task<TEntity> Get(long id);
        Task<TEntity> Add(TEntity entity);
        Task<ICollection<TEntity>> AddRange(ICollection<TEntity> entity);
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> Delete(Guid id);
        Task<TEntity> Delete(int id);
        Task<TEntity> Delete(long id);
    }
}
