
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class PilloryPunishment : PunishmentBase
    {

        [JsonPropertyName("params")]
        public PilloryPunishmentParams? Params { get; set; } = new();

        public PilloryPunishment()
        {
            Name = PunishmentName.Pillory;
        }

    }
}
