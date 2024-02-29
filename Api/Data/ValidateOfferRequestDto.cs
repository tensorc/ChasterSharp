using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class ValidateOfferRequestDto
    {
        [JsonPropertyName("accept")]
        public bool Accept { get; set; }

    }

}