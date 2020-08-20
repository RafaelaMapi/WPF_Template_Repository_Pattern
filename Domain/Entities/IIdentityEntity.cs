// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IIdentityEntity.cs" company="Gili Energy">
//   Copyright (c) 2019 All Rights Reserved
// </copyright>
// <summary>
//   Defines the IIdentityEntity type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace Domain.Entities
{
    /// <summary>
    /// The IdentityEntity <c>interface</c>.
    /// </summary>
    public interface IIdentityEntity
    {

        #region Properties

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        int Id { get; set; }

        #endregion

    }
}
