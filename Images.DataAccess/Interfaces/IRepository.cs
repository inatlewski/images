using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Images.Model.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Images.DataAccess.Interfaces
{
    /// <summary>
    /// Interface for a class which represents a generic repository of entities.
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        /// <summary>
        /// Gets the database context.
        /// </summary>
        /// <value>The database context.</value>
        ImagesContext DbContext { get; }

        /// <summary>
        /// Gets the object set.
        /// </summary>
        /// <value>The object set.</value>
        DbSet<TEntity> ObjectSet { get; }

        /// <summary>
        /// Adds the specified entity to the object set.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Add(TEntity entity, bool saveChanges = true);

        /// <summary>
        /// Updates the specified entity in the object set.
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity, bool saveChanges = true);
        
        /// <summary>
        /// Deletes the specified entity from the object set.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Delete(TEntity entity, bool saveChanges = true);

        /// <summary>
        /// Finds an entity in the object set using the primary key.
        /// </summary>
        /// <param name="primaryKey">The primary key.</param>
        /// <returns>The entity.</returns>
        TEntity FindByKey(params object[] primaryKey);

        /// <summary>
        /// Finds an entity in the object set using the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>The entity.</returns>
        TEntity Find(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Filters the object set using the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>The filtered object set.</returns>
        IEnumerable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate = null);

        /// <summary>
        /// Queries the object set using the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>The queryable object set.</returns>
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate = null);

        /// <summary>
        /// Saves the changes in the database context.
        /// </summary>
        void SaveChanges();
    }
}
