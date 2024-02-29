using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class PilloryConfig
    {
        [JsonPropertyName("timeToAdd")]
        public int TimeToAdd { get; set; } //NOTE: Max time is 86400

        [JsonPropertyName("limitToLoggedUsers")]
        public bool LimitToLoggedUsers { get; set; }
    }

}