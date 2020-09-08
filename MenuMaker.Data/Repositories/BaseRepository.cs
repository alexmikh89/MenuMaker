using MenuMaker.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MenuMaker.Data.Repositories
{
    public abstract class BaseRepository<TEntity, TKey> : INextRepository<TEntity, TKey>
        where TEntity : class, INextEntity<TKey>
    {
        public virtual TKey Create(TEntity entity)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var dbSet = ctx.Set<TEntity>();
                dbSet.Add(entity);
                var succes = ctx.SaveChanges();
                if (succes != 1)
                {
                    throw new Exception();
                }
                var addedEntityId = entity.Id;
                return addedEntityId;
            }
        }

        public virtual TEntity FindById(TKey id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var dbSet = ctx.Set<TEntity>();
                var result = dbSet.Find(id);
                return result;
            }
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var dbSet = ctx.Set<TEntity>();
                var result = dbSet.ToList();
                return result;
            }
        }

        public virtual IEnumerable<TEntity> GetAll(Func<TEntity, bool> func)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var dbSet = ctx.Set<TEntity>();
                var result = dbSet.AsNoTracking().Where(func).ToList();
                return result;
            }
        }

        public virtual void Remove(TKey id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var dbSet = ctx.Set<TEntity>();
                var entityToRemove = dbSet.Find(id);
                dbSet.Remove(entityToRemove);
                ctx.SaveChanges();
            }
        }

        public virtual void Update(TEntity entity)
        {
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Entry(entity).State = EntityState.Modified;
                ctx.SaveChanges();
            }
        }
    }
}
