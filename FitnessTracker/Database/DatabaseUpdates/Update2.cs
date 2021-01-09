// <copyright file="Update2.cs" company="TreverGannonsMadExperiment">
// Copyright (c) TreverGannonsMadExperiment. All rights reserved.
// </copyright>

namespace Database.DatabaseUpdates
{
    /// <summary>
    /// Represents the first iteration of the database.
    /// </summary>
    internal class Update2 : IUpdate
    {
        /// <inheritdoc/>
        public string UpdateSQL =>
@"
create table if not exists exercisetracker
(
	id uuid default gen_random_uuid() not null
		constraint exercisecounts_pkey
			primary key,
	repetitions integer not null,
	sets integer not null,
	person_id uuid not null
		constraint exercisecounts_person_id_fkey
			references person,
	exercise_id uuid not null
		constraint exercisecounts_exercise_id_fkey
			references exercise
);

alter table exercisetracker owner to postgres;
";

        /// <inheritdoc/>
        public int Priority => 2;
    }
}
