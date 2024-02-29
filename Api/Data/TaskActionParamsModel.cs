using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class TaskActionParamsModel
    {
        [JsonPropertyName("task")]
        public string? Task { get; set; } = default!;
        [JsonPropertyName("points")]
        public int Points { get; set; } = default!;
    }

}