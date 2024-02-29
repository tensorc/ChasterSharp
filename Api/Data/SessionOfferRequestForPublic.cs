using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class SessionOfferRequestForPublic
    {
        [JsonPropertyName("keyholder")]
        [Required]
        public UserForPublic Keyholder { get; set; } = new();
        [JsonPropertyName("lock")]
        [Required(AllowEmptyStrings = true)]
        public string Lock { get; set; } = default!;
        [JsonPropertyName("status")]
        [Required(AllowEmptyStrings = true)]
        [JsonConverter(typeof(CustomStringEnumConverter<SessionOfferRequestForPublicStatus>))]
        public SessionOfferRequestForPublicStatus Status { get; set; } = default!;
        [JsonPropertyName("validatedAt")]
        public DateTimeOffset? ValidatedAt { get; set; } = default!;
        [JsonPropertyName("archivedAt")]
        public DateTimeOffset? ArchivedAt { get; set; } = default!;

    }

}