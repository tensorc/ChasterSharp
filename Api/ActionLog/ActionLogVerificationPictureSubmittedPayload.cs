using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class ActionLogVerificationPictureSubmittedPayload
    {
        [JsonPropertyName("verificationCode")]
        public string? VerificationCode { get; set; }

        [JsonPropertyName("imageFile")]
        public string? ImageFile { get; set; }

        [JsonPropertyName("peerVerificationId")]
        public string? PeerVerificationId { get; set; }
    }

}