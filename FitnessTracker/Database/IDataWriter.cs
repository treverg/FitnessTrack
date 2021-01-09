// <copyright file="IDataWriter.cs" company="TreverGannonsMadExperiment">
// Copyright (c) TreverGannonsMadExperiment. All rights reserved.
// </copyright>

namespace Database
{
    using System.Threading.Tasks;
    using Microsoft.Extensions.Configuration;
    using Models;

    /// <summary>
    /// An interface for writing data for the fitness app.
    /// </summary>
    public interface IDataWriter
    {
        /// <summary>
        /// Gets configuration the fitness app is using.
        /// </summary>
        IConfiguration Configuration { get; }

        /// <summary>
        /// Gets or sets connection string name the app is using.
        /// </summary>
        string ConnectionStringName { get; set; }

        /// <summary>
        /// Writes a person to memory.
        /// </summary>
        /// <param name="person">The person to write.</param>
        /// <returns>A blank task.</returns>
        Task WritePerson(Person person);

        /// <summary>
        /// Writes a exercise.
        /// </summary>
        /// <param name="exercise">The exercise to write.</param>
        /// <returns>A blank task.</returns>
        Task WriteExercise(Exercise exercise);
    }
}