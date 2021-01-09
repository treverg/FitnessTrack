// <copyright file="IUpdate.cs" company="TreverGannonsMadExperiment">
// Copyright (c) TreverGannonsMadExperiment. All rights reserved.
// </copyright>

namespace Database.DatabaseUpdates
{
    /// <summary>
    /// Provides an update method for updating the database.
    /// </summary>
    internal interface IUpdate
    {
        /// <summary>
        /// Gets the update sql for the database.
        /// </summary>
        string UpdateSQL { get; }

        /// <summary>
        /// Gets the priority of the update statement.
        /// </summary>
        int Priority { get; }
    }
}
