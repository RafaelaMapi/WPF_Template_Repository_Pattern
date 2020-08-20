// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DomainRepository.cs" company="Gili Energy">
//   Copyright (c) 2019 All Rights Reserved
// </copyright>
// <summary>
//   Defines the DomainRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace DatabaseManager.Repositories.Standard.SQLite
{
  using DatabaseManager.Interfaces.DBConfigurations;
  using DatabaseManager.Interfaces.Repositories.Domain.Standard;
    using global::Domain.Entities;
    using global::SQLite;

    /// <summary>
    /// The domain repository.
    /// </summary>
    /// <typeparam name="TEntity">
    /// type of the class to use
    /// </typeparam>
    public class DomainRepository<TEntity> : RepositoryAsync<TEntity>,
                                             IDomainRepository<TEntity> where TEntity : class, IIdentityEntity, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DomainRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="database">
        /// The database.
        /// </param>
        protected DomainRepository(SQLiteAsyncConnection database) : base(database)
        {
        }
    }
}
