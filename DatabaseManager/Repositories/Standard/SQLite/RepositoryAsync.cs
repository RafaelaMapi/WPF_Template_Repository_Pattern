// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RepositoryAsync.cs" company="Gili ENergy">
//   Copyright (c) 2019 All Rights Reserved
// </copyright>
// <summary>
//   Defines the RepositoryAsync type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace DatabaseManager.Repositories.Standard.SQLite
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using DatabaseManager.Interfaces.DBConfigurations;
    using DatabaseManager.Interfaces.Repositories.Standard;
    using global::Domain.Entities;
    using global::SQLite;
    using SQLite;
    using SQLiteNetExtensions.Extensions;
    using SQLiteNetExtensionsAsync.Extensions;

    /// <summary>
    /// The repository async.
    /// </summary>
    /// <typeparam name="TEntity">
    /// type of the class to use
    /// </typeparam>
    public class RepositoryAsync<TEntity> : IRepositoryAsync<TEntity> where TEntity : class, IIdentityEntity, new()
    {
        /// <summary>
        /// The database.
        /// </summary>
        protected readonly SQLiteAsyncConnection Database;

        #region Functions

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryAsync{TEntity}"/> class.
        /// </summary>
        /// <param name="database">
        /// The database.
        /// </param>
        public RepositoryAsync(SQLiteAsyncConnection database)
        {
            Database = database;
        }

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public virtual async Task<List<TEntity>> GetAsync()
        { 
            return await Database.Table<TEntity>().ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// The get with children.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public virtual async Task<List<TEntity>> GetWithChildrenAsync()
        {
           
            return await Database.GetAllWithChildrenAsync<TEntity>(recursive: true).ConfigureAwait(false);
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public virtual async Task<TEntity> GetAsync(int id)
        {
            return await Database.FindAsync<TEntity>(id).ConfigureAwait(false);
        }

        /// <summary>
        /// The get with children.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public virtual async Task<TEntity> GetWithChildrenAsync(int id)
        {
            
            return await Database.FindWithChildrenAsync<TEntity>(id, recursive: true).ConfigureAwait(false);
        }

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
        public virtual async Task<List<TEntity>> GetAsync<TValue>(Expression<Func<TEntity, bool>> predicate = null, Expression<Func<TEntity, TValue>> orderBy = null)
        {
            var query = Database.Table<TEntity>();

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                query = query.OrderBy<TValue>(orderBy);

            return await query.ToListAsync().ConfigureAwait(false);
        }

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
        public virtual async Task<List<TEntity>> GetWithChildrenAsync<TValue>(Expression<Func<TEntity, bool>> predicate = null, Expression<Func<TEntity, TValue>> orderBy = null)
        {
            var query = await Database.GetAllWithChildrenAsync<TEntity>(recursive: true).ConfigureAwait(false) as AsyncTableQuery<TEntity>;

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                query = query.OrderBy<TValue>(orderBy);

            return await query.ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="predicate">
        /// The predicate.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
           return await Database.FindAsync<TEntity>(predicate).ConfigureAwait(false);
        }

        /// <summary>
        /// The get with children.
        /// </summary>
        /// <param name="predicate">
        /// The <c>predicate</c>.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public virtual async Task<TEntity> GetWithChildrenAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Database.FindWithChildrenAsync<TEntity>(predicate).ConfigureAwait(false);
        }

        /// <summary>
        /// The as query.
        /// </summary>
        /// <returns>
        /// The <see cref="AsyncTableQuery{T}"/>.
        /// </returns>
        public virtual  AsyncTableQuery<TEntity> AsQueryableAsync()
        {
            return Database.Table<TEntity>();
        }

        /// <summary>
        /// The insert.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public virtual async Task<TEntity> InsertAsync(TEntity entity)
        {
            await Database.InsertAsync(entity).ConfigureAwait(false);
            return entity;
        }

        /// <summary>
        /// The insert with children.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public virtual async Task<TEntity> InsertWithChildrenAsync(TEntity entity)
        {
            await Database.InsertWithChildrenAsync(entity, recursive: true).ConfigureAwait(false);
            return entity;
        }

        /// <summary>
        /// The insert all async.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public virtual async Task<List<TEntity>> InsertAllAsync(List<TEntity> entity)
        {
            await Database.InsertAllAsync(entity).ConfigureAwait(false);
            return entity;
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            await Database.UpdateAsync(entity).ConfigureAwait(false);
            return entity;
        }

        /// <summary>
        /// The update with children.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public virtual async Task<TEntity> UpdateWithChildrenAsync(TEntity entity)
        {
            await Database.UpdateWithChildrenAsync(entity).ConfigureAwait(false);
            return entity;
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public virtual async Task<TEntity> DeleteAsync(TEntity entity)
        {
            await Database.DeleteAsync(entity).ConfigureAwait(false);
            
            return entity;
        }

        /// <summary>
        /// The create table async.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public virtual async Task CreateTableAsync()
        {
            //await Database.DropTableAsync<TEntity>();
            await Database.CreateTableAsync<TEntity>();
        }

        #endregion   

    }
}
