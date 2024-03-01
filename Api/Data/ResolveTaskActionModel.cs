using System.Text.Json.Serialization;

namespace ChasterSharp;

public sealed class ResolveTaskActionModel
{
    [JsonPropertyName("isCompleted")]
    public bool IsCompleted { get; set; }
}