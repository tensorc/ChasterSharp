

using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public class PunishmentBase
    {
        [JsonPropertyName("name")]
        [JsonConverter(typeof(CustomStringEnumConverter<PunishmentName>))]
        public PunishmentName Name { get; set; }

    }
}
