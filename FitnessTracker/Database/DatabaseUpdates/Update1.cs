// <copyright file="Update1.cs" company="TreverGannonsMadExperiment">
// Copyright (c) TreverGannonsMadExperiment. All rights reserved.
// </copyright>

namespace Database.DatabaseUpdates
{
    /// <summary>
    /// Represents the first iteration of the database.
    /// </summary>
    internal class Update1 : IUpdate
    {
        /// <inheritdoc/>
        public string UpdateSQL =>
@"
CREATE EXTENSION pgcrypto;
create table if not exists person
(
	id uuid default gen_random_uuid() not null
		constraint person_pkey
			primary key,
	name text not null
);

alter table person owner to postgres;

create table if not exists exercise
(
	id uuid default gen_random_uuid() not null
		constraint exercise_pkey
			primary key,
	name text not null,
	example_video text,
	form_video text
);

alter table exercise owner to postgres;";

        /// <inheritdoc/>
        public int Priority => 1;
    }
}
