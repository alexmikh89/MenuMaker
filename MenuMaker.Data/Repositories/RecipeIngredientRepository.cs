﻿using MenuMaker.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuMaker.Data.Repositories
{
   public class RecipeIngredientRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public RecipeIngredientRepository() { }

        public void Create(TEntity entity)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var dbSet = ctx.Set<TEntity>();
                dbSet.Add(entity);
                ctx.SaveChanges();
            }
        }

        public TEntity FindById(int? id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var dbSet = ctx.Set<TEntity>();
                return dbSet.Find(id);
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var dbSet = ctx.Set<TEntity>();

                var e = ctx.RecipeIngridients.FirstOrDefault();
                ctx.Entry(e).Reference("Ingredient").Load();
                ctx.Entry(e).Reference("Recipe").Load();

                var result = dbSet.ToList();
                return result;
            }
        }

        public IEnumerable<TEntity> GetAll(Func<TEntity, bool> func)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var dbSet = ctx.Set<TEntity>();
                var result = dbSet.AsNoTracking().Where(func).ToList();
                return result;
            }
        }

        public void Remove(int? id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var dbSet = ctx.Set<TEntity>();
                var entityToRemove = dbSet.Find(id);
                dbSet.Remove(entityToRemove);
                ctx.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Entry(entity).State = EntityState.Modified;
                ctx.SaveChanges();
            }
        }
    }
}