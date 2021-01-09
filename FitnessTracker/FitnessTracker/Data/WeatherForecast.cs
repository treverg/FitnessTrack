// <copyright file="WeatherForecast.cs" company="TreverGannonsMadExperiment">
// Copyright (c) TreverGannonsMadExperiment. All rights reserved.
// </copyright>

namespace FitnessTracker.Data
{
    using System;

    /// <summary>
    /// Class for weather forcast.
    /// </summary>
    public class WeatherForecast
    {
        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the temp in c.
        /// </summary>
        public int TemperatureC { get; set; }

        /// <summary>
        /// Gets the temp in f.
        /// </summary>
        public int TemperatureF => 32 + (int)(this.TemperatureC / 0.5556);

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        public string Summary { get; set; }
    }
}
