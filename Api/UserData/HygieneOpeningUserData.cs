using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class HygieneOpeningUserData
    {
        [JsonPropertyName("openedAt")]
        public DateTimeOffset? OpenedAt { get; set; }
    }

}
