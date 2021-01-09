// <copyright file="IDataReader.cs" company="TreverGannonsMadExperiment">
// Copyright (c) TreverGannonsMadExperiment. All rights reserved.
// </copyright>

namespace Database
{
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Configuration;
    using Models;

    /// <summary>
    /// Used to read data for the fitness tracker app.
    /// </summary>
    public interface IDataReader
    {
        /// <summary>
        /// Gets configuration the reader needs.
        /// </summary>
        IConfiguration Configuration { get; }

        /// <summary>
        /// Gets or sets the connection string name.
        /// </summary>
        string ConnectionStringName { get; set; }

        /// <summary>
        /// Gets the people.
        /// </summary>
        /// <returns>A task containing a collection of people.</returns>
        Task<Collection<Person>> GetPeople();
    }
}