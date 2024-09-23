using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IUniversity.Core.Repository.Interface;
using IUniversity.Core.Repository.Interface.Base;
using Microsoft.EntityFrameworkCore;

namespace IUniversity.Core.Repository.Base
{
    public class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity, TContext>
        where TEntity : class
        where TContext : DbContext
    {
        protected readonly TContext Context;
        public BaseRepository(TContext context)
        {
            this.Context = context;
        }
        public async Task<TEntity> Add(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<ICollection<TEntity>> AddRange(ICollection<TEntity> entity)
        {
            await Context.Set<TEntity>().AddRangeAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Delete(Guid id)
        {
            var entity = await Context.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return null;
            }

            Context.Set<TEntity>().Remove(entity);
            await Context.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> Delete(int id)
        {
            var entity = await Context.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return null;
            }

            Context.Set<TEntity>().Remove(entity);
            await Context.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> Delete(long id)
        {
            var entity = await Context.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return null;
            }

            Context.Set<TEntity>().Remove(entity);
            await Context.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> Get(Guid id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> Get(int id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> Get(long id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return entity;
        }
    }
}
