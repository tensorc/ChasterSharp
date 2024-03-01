
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class WheelOfFortuneConfig
    {
        [JsonPropertyName("segments")]
        public List<WheelOfFortuneSegment> Segments { get; set; } = [];

    }

}