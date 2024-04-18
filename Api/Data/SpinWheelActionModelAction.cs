using System.Text.Json.Serialization;

namespace ChasterSharp;

public sealed class SpinWheelActionModelAction
{
    [JsonPropertyName("segment")] 
    public WheelOfFortuneSegmentModel Segment { get; set; } = new();
}