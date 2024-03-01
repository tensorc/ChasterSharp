using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public abstract class PenaltyBase
    {
        [JsonPropertyName("prefix")]
        public string? Prefix { get; set; } = "default";

        [JsonPropertyName("name")]
        [JsonConverter(typeof(CustomStringEnumConverter<PenaltyName>))]
        public PenaltyName Name { get; set; }

        [JsonPropertyName("punishments")]
        public List<JsonElement>? Punishments { get; set; } = default;

    }

}