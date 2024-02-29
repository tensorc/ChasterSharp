using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class ActionLogPilloryEndedPayload
    {
        [JsonPropertyName("timeAdded")]
        public int TimeAdded { get; set; }
    }

}