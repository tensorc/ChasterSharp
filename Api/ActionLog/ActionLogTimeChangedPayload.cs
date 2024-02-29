using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class ActionLogTimeChangedPayload
    {
        [JsonPropertyName("duration")]
        public int Duration { get; set; }
    }

}