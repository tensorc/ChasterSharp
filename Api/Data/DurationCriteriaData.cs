using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class DurationCriteriaData
    {
        [JsonPropertyName("minDuration")]
        public int MinDuration { get; set; } = default!;
        [JsonPropertyName("maxDuration")]
        public int MaxDuration { get; set; } = default!;

    }

}