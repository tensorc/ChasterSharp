using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class LogTimeChangedPayload
    {
        [JsonPropertyName("duration")]
        public int Duration { get; set; }
    }

}