// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDomainRepository.cs" company="Gili Energy">
//   Copyright (c) 2019 All Rights Reserved
// </copyright>
// <summary>
//   The DomainRepository interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------




namespace DatabaseManager.Interfaces.Repositories.Domain.Standard
{
    using DatabaseManager.Interfaces.Repositories.Standard;
    using global::Domain.Entities;

    /// <summary>
    /// The DomainRepository <c>interface</c>.
    /// </summary>
    /// <typeparam name="TEntity">
    /// Type of the class to use
    /// </typeparam>
    public interface IDomainRepository<TEntity> : IRepositoryAsync<TEntity> where TEntity : class, IIdentityEntity, new()
    {
    }
}
