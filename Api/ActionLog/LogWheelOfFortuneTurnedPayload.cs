
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class LogWheelOfFortuneTurnedPayload
    {
        [JsonPropertyName("segment")]
        public WheelOfFortuneSegmentModel Segment { get; set; } = new();

    }

}