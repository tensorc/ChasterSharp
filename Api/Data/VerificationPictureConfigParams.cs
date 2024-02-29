using System.Collections.ObjectModel;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class VerificationPictureConfigParams
    {
        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }

        [JsonPropertyName("punishments")]
        public ICollection<JsonElement>? Punishments { get; set; } = new Collection<JsonElement>();
    }

}