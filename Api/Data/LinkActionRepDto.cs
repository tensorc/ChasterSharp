using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class LinkActionRepDto
    {
        [JsonPropertyName("link")]
        public string? Link { get; set; } = default!;
    }

}