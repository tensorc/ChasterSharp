using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class PenaltiesConfig
    {
        [JsonPropertyName("penalties")]
        public List<JsonElement>? Penalties { get; set; } = default;
    }

}