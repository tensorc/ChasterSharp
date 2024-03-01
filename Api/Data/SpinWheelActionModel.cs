using System.Text.Json.Serialization;

namespace ChasterSharp;

public sealed class SpinWheelActionModel
{
    [JsonPropertyName("index")]
    public int Index { get; set; }

    [JsonPropertyName("action")] 
    public SpinWheelActionModelAction Action { get; set; } = new();

    [JsonPropertyName("text")]
    public string? Text { get; set; }
}