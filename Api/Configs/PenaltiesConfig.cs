using System.Collections.ObjectModel;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class PenaltiesConfig
    {
        [JsonPropertyName("penalties")]
        public ICollection<JsonElement>? Penalties { get; set; } = new Collection<JsonElement>();
    }

}