using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class ActionLogTemporaryOpeningOpenedPayload
    {
        [JsonPropertyName("openingTime")]
        public int OpeningTime { get; set; }

        [JsonPropertyName("penaltyTime")]
        public int PenaltyTime { get; set; }

        [JsonPropertyName("combination")]
        public string? Combination { get; set; } //TODO: Is this an Id?
    }

}