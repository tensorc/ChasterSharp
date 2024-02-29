using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class VerificationPictureHistoryEntry
    {
        /// <summary>
        /// The verification code
        /// </summary>
        [JsonPropertyName("verificationCode")]
        public string? VerificationCode { get; set; } = default!;
        /// <summary>
        /// The peer verification id
        /// </summary>
        [JsonPropertyName("peerVerificationId")]
        public string? PeerVerificationId { get; set; } = default!;
        /// <summary>
        /// The peer verification image key
        /// </summary>
        [JsonPropertyName("imageKey")]
        [Required(AllowEmptyStrings = true)]
        public string ImageKey { get; set; } = default!;
        /// <summary>
        /// Submitted at
        /// </summary>
        [JsonPropertyName("submittedAt")]
        [Required(AllowEmptyStrings = true)]
        public DateTimeOffset SubmittedAt { get; set; } = default!;
        /// <summary>
        /// Votes if the peer verification is enabled
        /// </summary>
        [JsonPropertyName("votes")]
        public PeerVerificationVoteStatus? Votes { get; set; } = default!;

    }

}