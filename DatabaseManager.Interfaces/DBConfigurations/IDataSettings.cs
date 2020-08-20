// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDataSettings.cs" company="Gili Energy">
//   Copyright (c) 2019 All Rights Reserved
// </copyright>
// <summary>
//   Defines the IDataSettings type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using SQLite;

namespace DatabaseManager.Interfaces.DBConfigurations
{
    /// <summary>
    /// The DataSettings interface.
    /// </summary>
    public interface IDataSettings
    {
        /// <summary>
        /// Gets or sets the default connection.
        /// </summary>
        SQLiteAsyncConnection DefaultConnection { get; set; }
    }
}
