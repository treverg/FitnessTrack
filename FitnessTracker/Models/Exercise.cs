// <copyright file="Exercise.cs" company="TreverGannonsMadExperiment">
// Copyright (c) TreverGannonsMadExperiment. All rights reserved.
// </copyright>

namespace Models
{
    using System;

    /// <summary>
    /// A class representing an exercise.
    /// </summary>
    public class Exercise
    {
        /// <summary>
        /// Gets or sets the unique ID.
        /// </summary>
        public Guid Guid { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Gets or sets the exercise name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the example video.
        /// </summary>
        public string ExampleVideo { get; set; }

        /// <summary>
        /// Gets or sets the video for form.
        /// </summary>
        public string FormVideo { get; set; }
    }
}
