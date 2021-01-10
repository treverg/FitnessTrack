// <copyright file="Person.cs" company="TreverGannonsMadExperiment">
// Copyright (c) TreverGannonsMadExperiment. All rights reserved.
// </copyright>

namespace Models
{
    using System;

    /// <summary>
    /// A model representing people.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Gets or sets unique identifier for people.
        /// </summary>
        public Guid Guid { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Gets or sets the name of a person.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Compares if two people are equal. They are equal if their GUIDS match.
        /// </summary>
        /// <param name="obj">The Person to compare.</param>
        /// <returns>Returns true if the two people are equal.</returns>
        public override bool Equals(object obj)
        {
            return obj is Person person &&
                   this.Guid.Equals(person.Guid);
        }

        /// <summary>
        /// Gets the hashcode of a person.
        /// </summary>
        /// <returns>Returns the hashcode of a person.</returns>
        public override int GetHashCode()
        {
            return -737073652 + this.Guid.GetHashCode();
        }
    }
}
