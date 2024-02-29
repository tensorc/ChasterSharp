
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class ActionLogTaskVoteEndedPayload
    {
        [JsonPropertyName("task")]
        public TaskPayload? Task { get; set; } = new();
    }

}