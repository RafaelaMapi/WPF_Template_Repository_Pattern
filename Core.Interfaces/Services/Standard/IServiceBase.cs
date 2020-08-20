// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IServiceBase.cs" company="Gili Energy">
//   Copyright (c) 2019 All Rights Reserved
// </copyright>
// <summary>
//   Defines the IServiceBase type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



namespace Core.Interfaces.Services.Standard
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using SQLite;

    /// <summary>
    /// The ServiceBase interface.
    /// </summary>
    /// <typeparam name="TEntity">
    /// Type of class to use
    /// </typeparam>
    public interface IServiceBase<TEntity> where TEntity : class, new()
    {
        /// <summary>
        /// The get async. 
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<List<TEntity>> GetAsync();

        /// <summary>
        /// The get with children async.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<List<TEntity>> GetWithChildrenAsync();

        /// <summary>
        /// The get async. 
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<TEntity> GetAsync(int id);

        /// <summary>
        /// The get with children async.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<TEntity> GetWithChildrenAsync(int id);

        // Task<List<TEntity>> GetAsync<TValue>(Expression<Func<TEntity, bool>> predicate = null, Expression<Func<TEntity, TValue>> orderBy = null);

        // Task<List<TEntity>> GetWithChildrenAsync<TValue>(Expression<Func<TEntity, bool>> predicate = null, Expression<Func<TEntity, TValue>> orderBy = null);

        // Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);

        // Task<TEntity> GetWithChildrenAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// The as queryable async.
        /// </summary>
        /// <returns>
        /// The <see cref="AsyncTableQuery"/>.
        /// </returns>
        AsyncTableQuery<TEntity> AsQueryableAsync();

        /// <summary>
        /// The insert async.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<TEntity> InsertAsync(TEntity entity);

        /// <summary>
        /// The insert with children.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<TEntity> InsertWithChildrenAsync(TEntity entity);

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<TEntity> UpdateAsync(TEntity entity);

        /// <summary>
        /// The update with children.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<TEntity> UpdateWithChildrenAsync(TEntity entity);

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<TEntity> DeleteAsync(TEntity entity);
    }
}
