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

        /// <summary>
        /// Compares if two exercises are equal.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns>Returns true if the two exercises are equal.</returns>
        public override bool Equals(object obj)
        {
            return obj is Exercise exercise &&
                   this.Guid.Equals(exercise.Guid);
        }

        /// <summary>
        /// Gets the hascode of the exercise.
        /// </summary>
        /// <returns>Returns the hashcode as an int.</returns>
        public override int GetHashCode()
        {
            return -737073652 + this.Guid.GetHashCode();
        }
    }
}
