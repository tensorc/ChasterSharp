
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class TimePunishment : PunishmentBase
    {

        [JsonPropertyName("params")]
        public int? Duration { get; set; }

        public TimePunishment()
        {
            Name = PunishmentName.AddTime;
        }

    }
}
