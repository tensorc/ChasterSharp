
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class TasksUserData
    {
        [JsonPropertyName("status")]
        [JsonConverter(typeof(CustomStringEnumConverter<TaskActionStatus>))]
        public TaskActionStatus Status { get; set; }

        [JsonPropertyName("voteStartedAt")]
        public DateTimeOffset? VoteStartedAt { get; set; }

        [JsonPropertyName("voteEndsAt")]
        public DateTimeOffset? VoteEndsAt { get; set; }

        [JsonPropertyName("currentTask")]
        public TaskPayload? CurrentTask { get; set; }

        [JsonPropertyName("userTasks")]
        public List<TaskPayload>? UserTasks { get; set; } = default;

        [JsonPropertyName("currentTaskVote")]
        public string? CurrentTaskVoteId { get; set; }

        [JsonPropertyName("points")]
        public int UserPoints { get; set; }
    }

}
