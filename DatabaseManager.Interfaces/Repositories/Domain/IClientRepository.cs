// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IClientRepository.cs" company="Gili Energy">
//   Copyright (c) 2019 All Rights Reserved
// </copyright>
// <summary>
//   The ClientRepository interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace DatabaseManager.Interfaces.Repositories.Domain
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DatabaseManager.Interfaces.Repositories.Domain.Standard;

    using global::Domain.Entities;

    /// <summary>
    /// The ClientRepository <c>interface</c>.
    /// </summary>
    public interface IClientRepository : IDomainRepository<Client>
    {
        
    }

}
