
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class LogWheelOfFortuneTurnedPayload
    {
        [JsonPropertyName("segment")]
        public WheelOfFortuneSegment Segment { get; set; } = new();

    }

}