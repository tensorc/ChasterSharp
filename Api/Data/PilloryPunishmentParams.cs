using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class PilloryPunishmentParams
    {
        [JsonPropertyName("duration")]
        public int Duration { get; set; }
    }
}
