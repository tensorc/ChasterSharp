
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class ActionLogWheelOfFortuneTurnedPayload
    {
        [JsonPropertyName("segment")]
        public WheelOfFortuneSegment Segment { get; set; } = new();

    }

}