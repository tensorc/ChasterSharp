

using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public class WheelOfFortuneSegmentModel
    {
        [JsonPropertyName("type")]
        [JsonConverter(typeof(CustomStringEnumConverter<WheelOfFortuneSegmentType>))]
        public WheelOfFortuneSegmentType Type { get; set; }

        [JsonPropertyName("duration")]
        public int Duration { get; set; }

        [JsonPropertyName("text")]
        public string? Text { get; set; }

    }

}