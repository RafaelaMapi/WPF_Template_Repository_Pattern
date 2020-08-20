// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceBase.cs" company="Gili Energy">
//   Copyright (c) 2019 All Rights Reserved
// </copyright>
// <summary>
//   Defines the ServiceBase type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------




namespace Core.Services.Standard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using DatabaseManager.Interfaces.Repositories.Standard;

    using global::Core.Interfaces.Services.Standard;

    using global::Domain.Entities;

    using SQLite;

    /// <summary>
    /// The service base.
    /// </summary>
    /// <typeparam name="TEntity">
    /// Type of the class to use
    /// </typeparam>
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class, IIdentityEntity, new()
    {

        #region Privates

        /// <summary>
        /// The repository.
        /// </summary>
        protected readonly IRepositoryAsync<TEntity> repository;

        #endregion                      

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBase{TEntity}"/> class.
        /// </summary>
        /// <param name="repository">
        /// The repository.
        /// </param>
        public ServiceBase(IRepositoryAsync<TEntity> repository)
        {
            this.repository = repository;
        }

        #region Functions

        /// <summary>
        /// The get async
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public virtual async Task<List<TEntity>> GetAsync()
        {
            return await repository.GetAsync();
        }

        /// <summary>
        /// The get with children async.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public virtual async Task<List<TEntity>> GetWithChildrenAsync()
        {
            return await repository.GetWithChildrenAsync();
        }

        /// <summary>
        /// The get async
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public virtual async Task<TEntity> GetAsync(int id)
        {
            return await repository.GetAsync(id);
        }

        /// <summary>
        /// The get with children async
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public virtual async Task<TEntity> GetWithChildrenAsync(int id)
        {
            return await repository.GetWithChildrenAsync(id);
        }

        /// <summary>
        /// The as queryable async
        /// </summary>
        /// <returns>
        /// The <see cref="AsyncTableQuery{T}"/>.
        /// </returns>
        public virtual AsyncTableQuery<TEntity> AsQueryableAsync()
        {
            return repository.AsQueryableAsync();
        }

        /// <summary>
        /// The insert async
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public virtual async Task<TEntity> InsertAsync(TEntity entity)
        {
            await repository.InsertAsync(entity);
            return entity;
        }

        /// <summary>
        /// The insert with children async
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public virtual async Task<TEntity> InsertWithChildrenAsync(TEntity entity)
        {
            await repository.InsertWithChildrenAsync(entity);
            return entity;
        }

        /// <summary>
        /// The update async
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            await repository.UpdateAsync(entity);
            return entity;
        }

        /// <summary>
        /// The update with children async
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public virtual async Task<TEntity> UpdateWithChildrenAsync(TEntity entity)
        {
            await repository.UpdateWithChildrenAsync(entity);
            return entity;
        }

        /// <summary>
        /// The delete async
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public virtual async Task<TEntity> DeleteAsync(TEntity entity)
        {
            await repository.DeleteAsync(entity);
            return entity;
        }

        #endregion                      

    }
}
