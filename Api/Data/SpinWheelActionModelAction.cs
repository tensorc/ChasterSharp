using System.Text.Json.Serialization;

namespace ChasterSharp;

public sealed class SpinWheelActionModelAction
{
    [JsonPropertyName("segment")] 
    public WheelOfFortuneSegment Segment { get; set; } = new();
}