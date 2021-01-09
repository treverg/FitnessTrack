// <copyright file="DataWriter.cs" company="TreverGannonsMadExperiment">
// Copyright (c) TreverGannonsMadExperiment. All rights reserved.
// </copyright>

namespace Database
{
    using System.Threading.Tasks;
    using Microsoft.Extensions.Configuration;
    using Models;
    using Npgsql;

    /// <summary>
    /// A class that interfaces with postgresql to write data.
    /// </summary>
    public class DataWriter : IDataWriter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataWriter"/> class.
        /// </summary>
        /// <param name="configuration">The configuration to use. Needs to contain a connection string.</param>
        public DataWriter(IConfiguration configuration)
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
        /// A method to write a person to the database.
        /// </summary>
        /// <param name="person">The person to write.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task WritePerson(Person person)
        {
            using (var con = new NpgsqlConnection(this.ConnectionString))
            {
                con.Open();

                var sql = "INSERT INTO Person (ID, Name) VALUES (@ID, @Name)";

                using (var cmd = new NpgsqlCommand(sql, con))
                {
                    cmd.Parameters.Add(new NpgsqlParameter("@Name", person.Name));
                    cmd.Parameters.Add(new NpgsqlParameter("@ID", person.Guid));
                    await Task.Run(() => cmd.ExecuteScalarAsync());
                }
            }
        }

        /// <summary>
        /// Writes a new exercise to the database.
        /// </summary>
        /// <param name="exercise">The exercise to write.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task WriteExercise(Exercise exercise)
        {
            using (var con = new NpgsqlConnection(this.ConnectionString))
            {
                con.Open();

                var sql = "INSERT INTO Exercise (ID, Name, Example_Video, Form_Video) VALUES (@ID, @Name, @Example_Video, @Form_Video)";

                using (var cmd = new NpgsqlCommand(sql, con))
                {
                    cmd.Parameters.Add(new NpgsqlParameter("@Name", exercise.Name));
                    cmd.Parameters.Add(new NpgsqlParameter("@ID", exercise.Guid));
                    cmd.Parameters.Add(new NpgsqlParameter("@Form_Video", exercise.FormVideo));
                    cmd.Parameters.Add(new NpgsqlParameter("@Example_Video", exercise.ExampleVideo));
                    await Task.Run(() => cmd.ExecuteScalarAsync());
                }
            }
        }
    }
}
