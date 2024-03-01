using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class SessionOfferRequestForKeyholder
    {
        [JsonPropertyName("keyholder")]
        [Required(AllowEmptyStrings = true)]
        public string Keyholder { get; set; } = default!;
        [JsonPropertyName("lock")]
        [Required]
        public UserForPublic Lock { get; set; } = new();
        [JsonPropertyName("status")]
        [Required(AllowEmptyStrings = true)]
        [JsonConverter(typeof(CustomStringEnumConverter<SessionOfferRequestStatus>))]
        public SessionOfferRequestStatus Status { get; set; } = default!;
        [JsonPropertyName("validatedAt")]
        public DateTimeOffset? ValidatedAt { get; set; } = default!;
        [JsonPropertyName("archivedAt")]
        public DateTimeOffset? ArchivedAt { get; set; } = default!;

    }

}