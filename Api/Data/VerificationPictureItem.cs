using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class VerificationPictureItem
    {
        [JsonPropertyName("imageKey")]
        [Required(AllowEmptyStrings = true)]
        public string ImageKey { get; set; } = default!;
        [JsonPropertyName("submittedAt")]
        [Required(AllowEmptyStrings = true)]
        public DateTimeOffset SubmittedAt { get; set; } = default!;
        [JsonPropertyName("verificationCode")]
        [Required(AllowEmptyStrings = true)]
        public string VerificationCode { get; set; } = default!;
        [JsonPropertyName("filename")]
        public string? Filename { get; set; } = default!;
        [JsonPropertyName("peerVerificationId")]
        public string? PeerVerificationId { get; set; } = default!;

    }

}