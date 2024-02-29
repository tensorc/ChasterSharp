using System.Collections.ObjectModel;
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
        public ICollection<JsonElement>? Punishments { get; set; } = new Collection<JsonElement>();

    }

}