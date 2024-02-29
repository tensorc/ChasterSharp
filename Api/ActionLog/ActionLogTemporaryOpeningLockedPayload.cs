using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class ActionLogTemporaryOpeningLockedPayload
    {
        [JsonPropertyName("unlockedTime")]
        public int UnlockedTime { get; set; }

        [JsonPropertyName("penaltyTime")]
        public int PenaltyTime { get; set; }
    }

}