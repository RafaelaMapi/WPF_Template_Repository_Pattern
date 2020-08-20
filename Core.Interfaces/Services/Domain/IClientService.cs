// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IClientService.cs" company="Gili Energy">
//   Copyright (c) 2019 All Rights Reserved
// </copyright>
// <summary>
//   Defines the IClientService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace Core.Interfaces.Services.Domain
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using global::Core.Interfaces.Services.Standard;

    using global::Domain.Entities;

    /// <summary>
    /// The ClientService interface.
    /// </summary>
    public interface IClientService : IServiceBase<Client>
    {
        /// <summary>
        /// The get all including tasks async.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<List<Client>> GetAllAsync();

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        List<Client> GetAll();

        /// <summary>
        /// The get by <c>name</c> including tasks async.
        /// </summary>
        /// <param name="name">
        /// The <c>name</c>.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<List<Client>> GetByNameAsync(string name);


        /// <summary>
        /// The save async
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<Client> SaveAsync(Client item);

        /// <summary>
        /// The create table.
        /// </summary>
        void CreateTable();
    }
}
