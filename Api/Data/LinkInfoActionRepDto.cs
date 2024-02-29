using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class LinkInfoActionRepDto
    {
        [JsonPropertyName("lockId")]
        public string? LockId { get; set; } = default!;

        [JsonPropertyName("extensionId")]
        public string? ExtensionId { get; set; } = default!;

        [JsonPropertyName("votes")]
        public int Votes { get; set; } = default!;

        [JsonPropertyName("minVotes")]
        public int MinVotes { get; set; } = default!;

        [JsonPropertyName("canVote")]
        public bool CanVote { get; set; } = default!;
    }

}