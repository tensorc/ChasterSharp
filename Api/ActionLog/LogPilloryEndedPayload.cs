using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class LogPilloryEndedPayload
    {
        [JsonPropertyName("timeAdded")]
        public int TimeAdded { get; set; }
    }

}