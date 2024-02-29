using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class PeerVerificationVoteStatus
    {
        /// <summary>
        /// Peer verification status
        /// </summary>
        [JsonPropertyName("status")]
        [Required(AllowEmptyStrings = true)]
        [JsonConverter(typeof(CustomStringEnumConverter<PeerVerificationStatus>))]
        public PeerVerificationStatus Status { get; set; } = default!;
        /// <summary>
        /// Peer verification id
        /// </summary>
        [JsonPropertyName("_id")]
        [Required(AllowEmptyStrings = true)]
        public string Id { get; set; } = default!;
        /// <summary>
        /// Number of verified votes
        /// </summary>
        [JsonPropertyName("verifiedVotes")]
        public int VerifiedVotes { get; set; } = default!;
        /// <summary>
        /// Number of rejected votes
        /// </summary>
        [JsonPropertyName("rejectedVotes")]
        public int RejectedVotes { get; set; } = default!;

    }

}