using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class CreateOfferRequestDto
    {
        [JsonPropertyName("keyholder")]
        [Required(AllowEmptyStrings = true)]
        public string Keyholder { get; set; } = default!;

    }

}