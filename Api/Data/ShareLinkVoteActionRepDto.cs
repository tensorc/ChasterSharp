using System.Text.Json.Serialization;

namespace ChasterSharp;

public sealed class ShareLinkVoteActionRepDto
{
    [JsonPropertyName("duration")]
    public int Duration { get; set; } = default!;
}