// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DatabaseFactory.cs" company="Gili Energy">
//   Copyright (c) 2019 All Rights Reserved
// </copyright>
// <summary>
//   Defines the DatabaseFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace DatabaseManager.DBConfiguration.SQLite
{
    using DatabaseManager.Interfaces.DBConfigurations;
    using global::SQLite;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Options;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Text;

    /// <summary>
    /// The database factory.
    /// </summary>
    public class DatabaseFactory //: IDatabaseFactory
    {

        #region Privates

        /// <summary>
        /// The data settings.
        /// </summary>
        private IOptions<DataSettings> dataSettings;

        #endregion    

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseFactory"/> class.
        /// </summary>
        /// <param name="dataSettings">
        /// The data settings.
        /// </param>
        public DatabaseFactory(IOptions<DataSettings> dataSettings)
        {
            this.dataSettings = dataSettings;
        }

        /// <summary>
        /// The get database connection.
        /// </summary>
        //public SQLiteAsyncConnection GetDbConnection => new SQLiteAsyncConnection(ConnectionString);

        /// <summary>
        /// The connection string.
        /// </summary>
        //protected string ConnectionString => 
            //!string.IsNullOrEmpty(dataSettings.Value.DefaultConnection) ?
            //                                     dataSettings.Value.DefaultConnection :
            //                                     DatabaseConnection.ConnectionConfiguration;


    }
}
