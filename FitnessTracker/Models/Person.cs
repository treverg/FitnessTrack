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
    }
}
