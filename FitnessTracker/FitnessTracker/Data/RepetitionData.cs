// <copyright file="RepetitionData.cs" company="TreverGannonsMadExperiment">
// Copyright (c) TreverGannonsMadExperiment. All rights reserved.
// </copyright>

namespace FitnessTracker.Data
{
    /// <summary>
    /// Data about how many repititions a user did.
    /// </summary>
    public class RepetitionData
    {
        /// <summary>
        /// Gets or sets the number of Curls a user did.
        /// </summary>
        public int Curls { get; set; }

        /// <summary>
        /// Gets or sets the number of overhead presses a user did.
        /// </summary>
        public int OverheadPress { get; set; }

        /// <summary>
        /// Gets or sets the number of deadlifts a user did.
        /// </summary>
        public int DeadLift { get; set; }

        /// <summary>
        /// Gets or sets the number of bench presses a user did.
        /// </summary>
        public int Bench { get; set; }

        /// <summary>
        /// Gets or sets the number of rows a user did.
        /// </summary>
        public int BentOverRow { get; set; }

        /// <summary>
        /// Gets or sets the number of squats someone did.
        /// </summary>
        public int Squat { get; set; }
    }
}
