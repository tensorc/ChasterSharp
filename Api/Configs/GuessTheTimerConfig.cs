using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class GuessTheTimerConfig
    {
        [JsonPropertyName("minRandomTime")]
        public int MinRandomTime { get; set; }

        [JsonPropertyName("maxRandomTime")]
        public int MaxRandomTime { get; set; }
    }

}