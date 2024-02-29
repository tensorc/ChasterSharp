﻿using System.Collections.ObjectModel;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class TasksConfig
    {
        [JsonPropertyName("tasks")]
        public ICollection<TaskPayload>? Tasks { get; set; } = new Collection<TaskPayload>();

        [JsonPropertyName("voteEnabled")]
        public bool VoteEnabled { get; set; }

        [JsonPropertyName("voteDuration")]
        public int VoteDuration { get; set; }

        [JsonPropertyName("startVoteAfterLastVote")]
        public bool StartVoteAfterLastVote { get; set; }

        [JsonPropertyName("enablePoints")]
        public bool EnablePoints { get; set; }

        [JsonPropertyName("pointsRequired")]
        public int PointsRequired { get; set; }

        [JsonPropertyName("allowWearerToEditTasks")]
        public bool AllowWearerToEditTasks { get; set; }

        [JsonPropertyName("allowWearerToConfigureTasks")]
        public bool AllowWearerToConfigureTasks { get; set; }

        [JsonPropertyName("preventWearerFromAssigningTasks")]
        public bool PreventWearerFromAssigningTasks { get; set; }

        [JsonPropertyName("allowWearerToChooseTasks")]
        public bool AllowWearerToChooseTasks { get; set; }

        [JsonPropertyName("actionsOnAbandonedTask")]
        public ICollection<JsonElement>? PunishmentsOnAbandonedTask { get; set; } = new Collection<JsonElement>(); //Punishments
    }

}