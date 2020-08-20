
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DatabaseConnection.cs" company="Gili Energy">
//   Copyright (c) 2019 All Rights Reserved
// </copyright>
// <summary>
//   Defines the DatabaseConnection type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace DatabaseManager.DBConfiguration
{
    using Microsoft.Extensions.Configuration;
    using System;
    using System.IO;

    /// <summary>
    /// The database connection.
    /// </summary>
    public class DatabaseConnection
    {

        #region Properties

        /// <summary>
        /// The connection configuration.
        /// </summary>
        public static IConfiguration ConnectionConfiguration
        {
            get
            {
                var path = $"{Directory.GetParent(Directory.GetCurrentDirectory()).ToString()}\\Infrastructure";
                IConfigurationRoot Configuration = new ConfigurationBuilder()
                    .SetBasePath(path)
                    .AddJsonFile("appsettings.json")
                    .Build();
                return Configuration;
            }
        }

        #endregion   
    }
}
