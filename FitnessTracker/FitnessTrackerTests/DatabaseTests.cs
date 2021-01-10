// <copyright file="DatabaseTests.cs" company="TreverGannonsMadExperiment">
// Copyright (c) TreverGannonsMadExperiment. All rights reserved.
// </copyright>

namespace FitnessTrackerTests
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Reflection;
    using System.Threading.Tasks;
    using Database;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Hosting;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// A class to test the database functionality.
    /// </summary>
    [TestClass]
    public class DatabaseTests
    {
        private static IConfiguration Configuration { get; set; }

        /// <summary>
        /// Initalizes the database.
        /// </summary>
        [AssemblyInitialize]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1611:Element parameters should be documented", Justification = "Required by microsofts testing framework.")]
        public static void AssemblyInit(TestContext context)
        {
            Configuration = new ConfigurationBuilder()
            .SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.Development.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

            DatabaseCreator creator = new DatabaseCreator(Configuration);
            creator.CreateDatabase("UnitTests").Wait();
        }

        /// <summary>
        /// Tests reading values from the people table.
        /// </summary>
        [TestMethod]
        public void GetPeople()
        {
            IDataReader reader = new DataReader(Configuration);
            reader.GetPeople();
        }

        /// <summary>
        /// Tests reading values from the exercise table.
        /// </summary>
        [TestMethod]
        public void GetExercises()
        {
            IDataReader reader = new DataReader(Configuration);
            reader.GetExercises();
        }

        /// <summary>
        /// Tests writing a person to the database.
        /// </summary>
        [TestMethod]
        public void WritePerson()
        {
            Task task = new Task(async () =>
            {
                var personToWrite = new Models.Person() { Name = "Test" };
                IDataWriter dataWriter = new DataWriter(Configuration);
                await dataWriter.WritePerson(personToWrite);

                IDataReader reader = new DataReader(Configuration);
                var people = await reader.GetPeople();
                if (!people.Contains(personToWrite))
                {
                    throw new Exception("Person failed to write to database");
                }
            });
            task.RunSynchronously();
        }

        /// <summary>
        /// Tests writing an exercise to the database.
        /// </summary>
        [TestMethod]
        public void WriteExercise()
        {
            Task task = new Task(async () =>
            {
                var exerciseToWrite = new Models.Exercise()
                {
                    Name = "Squat",
                    ExampleVideo = "Http://SomeVideo",
                    FormVideo = "http://SomeForm",
                };

                IDataWriter dataWriter = new DataWriter(Configuration);
                await dataWriter.WriteExercise(exerciseToWrite);

                IDataReader reader = new DataReader(Configuration);
                var exercises = await reader.GetExercises();
                if (!exercises.Contains(exerciseToWrite))
                {
                    throw new Exception("Exercise failed to write to database");
                }
            });
            task.RunSynchronously();
        }

        /// <summary>
        /// Removes the database after running tests.
        /// </summary>
        [TestCleanup]
        public void Cleanup()
        {
            Console.WriteLine("hi");
        }
    }
}
