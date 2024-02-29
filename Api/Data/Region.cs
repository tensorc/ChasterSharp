using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class Region
    {
        [JsonPropertyName("name")]
        [Required(AllowEmptyStrings = true)]
        public string Name { get; set; } = default!;
        [JsonPropertyName("shortCode")]
        public string? ShortCode { get; set; } = default!;

    }

}