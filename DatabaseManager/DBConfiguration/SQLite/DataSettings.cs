// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataSettings.cs" company="Gili Energy">
//   Copyright (c) 2019 All Rights Reserved
// </copyright>
// <summary>
//   Defines the DataSettings type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



namespace DatabaseManager.DBConfiguration.SQLite
{
    using DatabaseManager.Interfaces.DBConfigurations;
    using System;

    using global::SQLite;

    /// <summary>
    /// The data settings.
    /// </summary>
    public class DataSettings : IDataSettings
    {

        #region Properties

        /// <summary>
        /// Gets or sets the default connection.
        /// </summary>
        public SQLiteAsyncConnection DefaultConnection { get; set; }

        #endregion   

    }
}
