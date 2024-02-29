using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class PilloryVoteInfoActionRepDto
    {
        [JsonPropertyName("_id")]
        public string? Id { get; set; } = default!;

        [JsonPropertyName("nbVotes")]
        public int Votes { get; set; } = default!;

        [JsonPropertyName("totalDurationAdded")]
        public int TotalDurationAdded { get; set; } = default!;

        [JsonPropertyName("voteEndsAt")]
        public DateTimeOffset? VoteEndsAt { get; set; } = default!;

        [JsonPropertyName("canVote")]
        public bool CanVote { get; set; } = default!;

        [JsonPropertyName("reason")]
        public string? Reason { get; set; } = default!;

        [JsonPropertyName("createdAt")]
        public DateTimeOffset? CreatedAt { get; set; } = default!;
    }

}