

using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public abstract class PunishmentBase
    {
        [JsonPropertyName("name")]
        [JsonConverter(typeof(CustomStringEnumConverter<PunishmentName>))]
        public PunishmentName Name { get; set; }

    }
}
