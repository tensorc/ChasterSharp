using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class ActionLogMaxLimitDateIncreasedPayload
    {
        [JsonPropertyName("date")]
        public DateTimeOffset Date { get; set; }
    }

}