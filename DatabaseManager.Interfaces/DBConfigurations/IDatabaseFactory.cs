// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDatabaseFactory.cs" company="Gili Energy">
//   Copyright (c) 2019 All Rights Reserved
// </copyright>
// <summary>
//   Defines the IDatabaseFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace DatabaseManager.Interfaces.DBConfigurations
{
    using SQLite;

    /// <summary>
    /// The DatabaseFactory interface.
    /// </summary>
    public interface IDatabaseFactory
    {
        /// <summary>
        /// Gets the get database connection.
        /// </summary>
        SQLiteAsyncConnection GetDbConnection { get; }
    }
}
