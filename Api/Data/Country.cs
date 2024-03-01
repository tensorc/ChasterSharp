using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class Country
    {
        [JsonPropertyName("countryName")]
        [Required(AllowEmptyStrings = true)]
        public string CountryName { get; set; } = default!;
        [JsonPropertyName("countryShortCode")]
        [Required(AllowEmptyStrings = true)]
        public string CountryShortCode { get; set; } = default!;
        [JsonPropertyName("regions")]
        public List<Region>? Regions { get; set; } = default;

    }

}