
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class LogTaskVoteEndedPayload
    {
        [JsonPropertyName("task")]
        public TaskPayload? Task { get; set; } = new();
    }

}