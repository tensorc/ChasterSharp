using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class AssignTaskActionModel
    {
        [JsonPropertyName("task")]
        public TaskActionParamsModel Task { get; set; } = new();
    }
}