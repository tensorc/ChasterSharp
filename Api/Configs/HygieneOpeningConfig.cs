using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class HygieneOpeningConfig
    {
        [JsonPropertyName("openingTime")]
        public int OpeningTime { get; set; }

        [JsonPropertyName("penaltyTime")]
        public int PenaltyTime { get; set; }

        [JsonPropertyName("allowOnlyKeyholderToOpen")]
        public bool AllowOnlyKeyholderToOpen { get; set; }
    }

}