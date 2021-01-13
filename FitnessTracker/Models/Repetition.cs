// <copyright file="Repetition.cs" company="TreverGannonsMadExperiment">
// Copyright (c) TreverGannonsMadExperiment. All rights reserved.
// </copyright>

namespace Models
{
    /// <summary>
    /// A class used to track the number of repititions.
    /// </summary>
    public class Repetition
    {
        /// <summary>
        /// Gets or sets the current set the user is on.
        /// </summary>
        public int SetNumber { get; set; }

        /// <summary>
        /// Gets or sets the number of repititions the user got for that set.
        /// </summary>
        public int RepCount { get; set; }
    }
}
