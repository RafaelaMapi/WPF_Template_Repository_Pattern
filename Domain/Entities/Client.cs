// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Client.cs" company="Gili Energy">
//   Copyright (c) 2019 All Rights Reserved
// </copyright>
// <summary>
//   Defines the Client type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace Domain.Entities
{
    using System.Collections.Generic;

    using SQLite;

    using SQLiteNetExtensions.Attributes;

    /// <summary>
    /// The client.
    /// </summary>
    public class Client : IIdentityEntity
    {

        #region Properties

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

       

        #endregion                      

    }
}
