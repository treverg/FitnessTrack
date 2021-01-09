// <copyright file="Program.cs" company="TreverGannonsMadExperiment">
// Copyright (c) TreverGannonsMadExperiment. All rights reserved.
// </copyright>

namespace FitnessTracker
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;

    /// <summary>
    /// The default startup instance for blazor.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The start of the blazor application.
        /// </summary>
        /// <param name="args">The arguments to pass blazor.</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Creates a default host builder for blazor.
        /// </summary>
        /// <param name="args">The program arugments.</param>
        /// <returns>The host builder for the application.</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
