using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class LogTemporaryOpeningLockedPayload
    {
        [JsonPropertyName("unlockedTime")]
        public float UnlockedTime { get; set; }

        [JsonPropertyName("penaltyTime")]
        public int PenaltyTime { get; set; }
    }

}