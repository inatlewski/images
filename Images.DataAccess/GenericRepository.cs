using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Images.DataAccess.Interfaces;
using Images.Model.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Images.DataAccess
{
    /// <summary>
    /// Represents a generic repository of entities.
    /// Implements the <see cref="Images.DataAccess.Interfaces.IRepository{TEntity}" />
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    /// <seealso cref="Images.DataAccess.Interfaces.IRepository{TEntity}" />
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        /// <summary>
        /// Gets the database context.
        /// </summary>
        /// <value>The database context.</value>
        public ImagesContext DbContext { get; }

        /// <summary>
        /// Gets the object set.
        /// </summary>
        /// <value>The object set.</value>
        public DbSet<TEntity> ObjectSet { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public GenericRepository(ImagesContext dbContext)
        {
            DbContext = dbContext;
            ObjectSet = DbContext.Set<TEntity>();
        }

        /// <summary>
        /// Adds the specified entity to the object set.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Add(TEntity entity)
        {
            ObjectSet.Add(entity);
        }

        /// <summary>
        /// Deletes the specified entity from the object set.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(TEntity entity)
        {
            ObjectSet.Remove(entity);
        }

        /// <summary>
        /// Finds an entity in the object set using the primary key.
        /// </summary>
        /// <param name="primaryKey">The primary key.</param>
        /// <returns>The entity.</returns>
        public TEntity FindByKey(params object[] primaryKey)
        {
            var foundObject = ObjectSet.Find(primaryKey);
            
            return foundObject;
        }

        /// <summary>
        /// Finds an entity in the object set using the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>The entity.</returns>
        public TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            var firstObject = ObjectSet.First(predicate);

            return firstObject;
        }

        /// <summary>
        /// Filters the object set using the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>The filtered object set.</returns>
        public IEnumerable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return ObjectSet.Where(predicate);
            }

            return ObjectSet.AsEnumerable();
        }

        /// <summary>
        /// Queries the object set using the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>The queryable object set.</returns>
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
