// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClientRepository.cs" company="Gili Energy">
//   Copyright (c) 2019 All Rights Reserved
// </copyright>
// <summary>
//   Defines the ClientRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace DatabaseManager.Repositories.Domain.SQLite
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DatabaseManager.Interfaces.DBConfigurations;
    using DatabaseManager.Interfaces.Repositories.Domain;
    using DatabaseManager.Repositories.Standard.SQLite;

    using global::Domain.Entities;
    using global::SQLite;

    /// <summary>
    /// The kind repository.
    /// </summary>
    public class ClientRepository : DomainRepository<Client>,
                                    IClientRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientRepository"/> class.
        /// </summary>
        /// <param name="database">
        /// The database.
        /// </param>
        public ClientRepository(SQLiteAsyncConnection database)
            : base(database)
        {

        }

    }
}
