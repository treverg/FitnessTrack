// <copyright file="DataReader.cs" company="TreverGannonsMadExperiment">
// Copyright (c) TreverGannonsMadExperiment. All rights reserved.
// </copyright>

namespace Database
{
    using System;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Configuration;
    using Models;
    using Npgsql;

    /// <summary>
    /// A class used to read data from posgresql.
    /// </summary>
    public class DataReader : IDataReader
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataReader"/> class.
        /// </summary>
        /// <param name="configuration">The configuration to use. Needs to contain a connection string.</param>
        public DataReader(IConfiguration configuration)
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
        public string ConnectionStringName { get; set; } = "Default";

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
        /// Reads people from the database.
        /// </summary>
        /// <returns>A <see cref="Task"/> that returns people.</returns>
        public async Task<Collection<Person>> GetPeople()
        {
            Collection<Person> people = new Collection<Person>();
            using (var con = new NpgsqlConnection(this.ConnectionString))
            {
                con.Open();

                var sql = "SELECT ID, Name FROM PERSON";

                using (var cmd = new NpgsqlCommand(sql, con))
                {
                    NpgsqlDataReader reader = await Task.Run(() => cmd.ExecuteReader());
                    while (reader.Read())
                    {
                        people.Add(new Person()
                        {
                            Guid = Guid.Parse(reader[0].ToString()),
                            Name = reader[1].ToString(),
                        });
                    }
                }
            }

            return people;
        }
    }
}
