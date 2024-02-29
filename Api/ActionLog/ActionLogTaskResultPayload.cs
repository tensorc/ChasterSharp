
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class ActionLogTaskResultPayload
    {
        [JsonPropertyName("task")]
        public TaskPayload? Task { get; set; } = new();

        [JsonPropertyName("points")]
        public int Points { get; set; }
    }

}