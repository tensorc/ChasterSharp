using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class ShareLinkConfig
    {
        [JsonPropertyName("timeToAdd")]
        public int TimeToAdd { get; set; }

        [JsonPropertyName("timeToRemove")]
        public int TimeToRemove { get; set; }

        [JsonPropertyName("enableRandom")]
        public bool EnableRandom { get; set; }

        [JsonPropertyName("nbVisits")]
        public int RequiredVisits { get; set; }

        [JsonPropertyName("limitToLoggedUsers")]
        public bool LimitToLoggedUsers { get; set; }
    }

}