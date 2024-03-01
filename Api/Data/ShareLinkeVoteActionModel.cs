using System.Text.Json.Serialization;

namespace ChasterSharp;

public sealed class ShareLinkeVoteActionModel
{
    [JsonPropertyName("action")]
    [JsonConverter(typeof(CustomStringEnumConverter<ShareLinkVoteAction>))]
    public ShareLinkVoteAction Action { get; set; }

    [JsonPropertyName("sessionId")]
    public string SessionId { get; set; }
}