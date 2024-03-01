using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class VerificationPictureConfigParams
    {
        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }

        [JsonPropertyName("punishments")]
        public List<JsonElement>? Punishments { get; set; } = default;
    }

}