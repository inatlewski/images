using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Images.DataAccess.Interfaces;
using Images.Model.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Images.DataAccess
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        public ImagesContext DbContext { get; }

        public DbSet<TEntity> ObjectSet { get; }

        public GenericRepository(ImagesContext dbContext)
        {
            DbContext = dbContext;
            ObjectSet = DbContext.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            ObjectSet.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            ObjectSet.Remove(entity);
        }

        public TEntity FindByKey(params object[] primaryKey)
        {
            var foundObject = ObjectSet.Find(primaryKey);
            
            return foundObject;
        }

        public TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            var firstObject = ObjectSet.First(predicate);

            return firstObject;
        }

        public IEnumerable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return ObjectSet.Where(predicate);
            }

            return ObjectSet.AsEnumerable();
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return ObjectSet.Where(predicate);
            }

            return ObjectSet.AsQueryable();
        }
    }
}
