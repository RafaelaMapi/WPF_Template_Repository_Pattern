// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClientService.cs" company="Gili Energy">
//   Copyright (c) 2019 All Rights Reserved
// </copyright>
// <summary>
//   Defines the ClientService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace Core.Services.Domain
{
    // using Application.Interfaces.Services.Domain;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Core.Helpers;
    using Core.Services.Standard;

    using DatabaseManager.Interfaces.Repositories.Domain;

    using global::Core.Interfaces.Services.Domain;

    using global::Domain.Entities;

    /// <summary>
    /// The Client service.
    /// </summary>
    public class ClientService : ServiceBase<Client>, IClientService
    {

        #region Privates

        /// <summary>
        /// The _repository.
        /// </summary>
        private readonly IClientRepository _repository;

        #endregion                      

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientService"/> class.
        /// </summary>
        /// <param name="repository">
        /// The repository.
        /// </param>
        public ClientService(IClientRepository repository) : base(repository)
        {
            _repository = repository;
        }

        #region Functions

        /// <summary>
        /// The create table.
        /// </summary>
        public void CreateTable()
        {
            Task.Run(async () => await _repository.CreateTableAsync());
        }

        /// <summary>
        /// The get all including tasks async.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<List<Client>> GetAllAsync()
        {
            return await _repository.GetAsync();
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<Client> GetAll()
        {
            Task<List<Client>> result_a = Task.Run(async () => await _repository.GetAsync());
           return result_a.Result;
        }

        /// <summary>
        /// The get by name including tasks async.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<List<Client>> GetByNameAsync(string name)
        {
            var itens = await _repository.GetAsync();

            if (name.ToLower() == "all")
            {
                return itens;
            }

            string toFind = Accents.Remove(name.ToLower());
            var kinds = itens.Where(x => Accents.Remove(x.Name).ToLower().Contains(toFind)).ToList();
            return kinds;

        }

        /// <summary>
        /// The save async.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<Client> SaveAsync(Client item)
        {
            if (item != null)
            {
                if (item.Id != 0)
                {
                    return await _repository.UpdateAsync(item);
                }
                else
                {
                    return await _repository.InsertAsync(item);
                }
            }

            return null;
        }
        #endregion                      

    }
}
