// <copyright file="DatabaseCreator.cs" company="TreverGannonsMadExperiment">
// Copyright (c) TreverGannonsMadExperiment. All rights reserved.
// </copyright>

namespace Database
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;
    using Database.DatabaseUpdates;
    using Microsoft.Extensions.Configuration;
    using Npgsql;

    /// <summary>
    /// A class used to create a database for the fitness tracker app.
    /// </summary>
    public class DatabaseCreator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseCreator"/> class.
        /// </summary>
        /// <param name="configuration">The configuration to use. Needs to contain a connection string.</param>
        public DatabaseCreator(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        /// <summary>
        /// Gets the configuration the solution is using.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Gets or Sets connection string to use.
        /// </summary>
        public string ConnectionStringName { get; set; } = "Creation";

        /// <summary>
        /// Gets value of the connection string.
        /// </summary>
        private string ConnectionString
        {
            get
            {
                return this.Configuration.GetConnectionString(this.ConnectionStringName);
            }
        }

        /// <summary>
        /// Drops the existing database with that name, and creates a new one. WARNING DANGEROUS.
        /// Please ensure the databaseName exists in the appsettings.json.
        /// </summary>
        /// <param name="databaseName">The database name to create.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task CreateDatabase(string databaseName)
        {
            using (var con = new NpgsqlConnection(this.ConnectionString))
            {
                con.Open();

                using (var cmd = new NpgsqlCommand(
                                        $@"DROP DATABASE IF EXISTS {databaseName};
                                        CREATE DATABASE {databaseName};", con))
                {
                    await cmd.ExecuteScalarAsync();
                }
            }

            await this.UpdateDatabase(databaseName);
        }

        /// <summary>
        /// Destorys a database, and all of its tables. (Not the tables!).
        /// </summary>
        /// <param name="databaseName">The database to destroy.</param>
        /// <returns>A task to execute the destory.</returns>
        public async Task DestoryDatabaseMuhahaha(string databaseName)
        {
            using (var con = new NpgsqlConnection(this.ConnectionString))
            {
                con.Open();

                using (var cmd = new NpgsqlCommand(
                    $@"
                        SELECT pid, pg_terminate_backend(pid) 
                        FROM pg_stat_activity 
                        WHERE datname = current_database() AND pid <> pg_backend_pid();
                        DROP DATABASE IF EXISTS {databaseName};", con))
                {
                    await cmd.ExecuteScalarAsync();
                }
            }
        }

        private async Task UpdateDatabase(string databaseName)
        {
            this.ConnectionStringName = databaseName;
            using (var con = new NpgsqlConnection(this.ConnectionString))
            {
                con.Open();
                var updates = this.GetClassesThatImplementInterface<IUpdate>();
                foreach (var update in updates)
                {
                    using (var cmd = new NpgsqlCommand(update.UpdateSQL, con))
                    {
                        await cmd.ExecuteScalarAsync();
                    }
                }
            }
        }

        private List<T> GetClassesThatImplementInterface<T>()
        {
            return Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .Where(type => typeof(T).IsAssignableFrom(type))
                    .Where(type =>
                        !type.IsAbstract &&
                        !type.IsGenericType &&
                        type.GetConstructor(new Type[0]) != null)
                    .Select(type => (T)Activator.CreateInstance(type))
                    .ToList();
        }
    }
}
