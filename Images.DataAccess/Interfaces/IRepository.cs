using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Images.Model.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Images.DataAccess.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        ImagesContext DbContext { get; }

        DbSet<TEntity> ObjectSet { get; }

        void Add(TEntity entity);
        
        void Delete(TEntity entity);

        TEntity FindByKey(params object[] primaryKey);

        TEntity Find(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate = null);

        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate = null);
    }
}
