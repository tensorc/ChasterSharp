using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class LogMaxLimitDateIncreasedPayload
    {
        [JsonPropertyName("date")]
        public DateTimeOffset Date { get; set; }
    }

}