using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class TaskPayload
    {
        [JsonPropertyName("task")]
        public string? Task { get; set; }

        [JsonPropertyName("points")]
        public int Points { get; set; }
    }

}