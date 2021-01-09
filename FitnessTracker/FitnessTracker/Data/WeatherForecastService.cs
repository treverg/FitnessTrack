// <copyright file="WeatherForecastService.cs" company="TreverGannonsMadExperiment">
// Copyright (c) TreverGannonsMadExperiment. All rights reserved.
// </copyright>

namespace FitnessTracker.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Class for weather forcast service.
    /// </summary>
    public class WeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching",
        };

        /// <summary>
        /// Gets the forcast.
        /// </summary>
        /// <param name="startDate">Date to start.</param>
        /// <returns>Returns a forcast.</returns>
        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            var rng = new Random();
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)],
            }).ToArray());
        }
    }
}
