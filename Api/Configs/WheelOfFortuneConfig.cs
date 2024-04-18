
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class WheelOfFortuneConfig
    {
        [JsonPropertyName("segments")]
        public List<WheelOfFortuneSegmentModel> Segments { get; set; } = [];

    }

}