// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRepositoryAsync.cs" company="Gili Energy">
//   Copyright (c) 2019 All Rights Reserved
// </copyright>
// <summary>
//   Defines the IRepositoryAsync type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------




namespace DatabaseManager.Interfaces.Repositories.Standard
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using global::Domain.Entities;
    using SQLite;

    /// <summary>
    /// The RepositoryAsync <c>interface</c>.
    /// </summary>
    /// <typeparam name="TEntity">
    /// Type of class to use
    /// </typeparam>
    public interface IRepositoryAsync<TEntity> : IDisposable where TEntity : class, IIdentityEntity, new()
    {
        /// <summary>
        /// The get.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<List<TEntity>> GetAsync();

        /// <summary>
        /// The get with children.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<List<TEntity>> GetWithChildrenAsync();

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<TEntity> GetAsync(int id);

        /// <summary>
        /// The get with children.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<TEntity> GetWithChildrenAsync(int id);

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="predicate">
        /// The <c>predicate</c>.
        /// </param>
        /// <param name="orderBy">
        /// The order by.
        /// </param>
        /// <typeparam name="TValue">
        /// the class to use
        /// </typeparam>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<List<TEntity>> GetAsync<TValue>(Expression<Func<TEntity, bool>> predicate = null, Expression<Func<TEntity, TValue>> orderBy = null);

        /// <summary>
        /// The get with children.
        /// </summary>
        /// <param name="predicate">
        /// The <c>predicate</c>.
        /// </param>
        /// <param name="orderBy">
        /// The order by.
        /// </param>
        /// <typeparam name="TValue">
        /// type of model to use
        /// </typeparam>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<List<TEntity>> GetWithChildrenAsync<TValue>(Expression<Func<TEntity, bool>> predicate = null, Expression<Func<TEntity, TValue>> orderBy = null);

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="predicate">
        /// The predicate.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// The get with children.
        /// </summary>
        /// <param name="predicate">
        /// The <c>predicate</c>.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<TEntity> GetWithChildrenAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// The as query.
        /// </summary>
        /// <returns>
        /// The <see cref="AsyncTableQuery"/>.
        /// </returns>
        AsyncTableQuery<TEntity> AsQueryableAsync();

        /// <summary>
        /// The insert.
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
        /// The insert all async.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<List<TEntity>> InsertAllAsync(List<TEntity> entity);

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

        /// <summary>
        /// The create table async.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task CreateTableAsync();

    }
}
