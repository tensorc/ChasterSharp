using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class KeyholderSearchLocksRepDto
    {
        /// <summary>
        /// Number of pages
        /// </summary>
        [JsonPropertyName("pages")]
        public int Pages { get; set; } = default!;
        /// <summary>
        /// Number of results
        /// </summary>
        [JsonPropertyName("total")]
        public int Total { get; set; } = default!;
        /// <summary>
        /// List of locks
        /// </summary>
        [JsonPropertyName("locks")]
        [Required]
        public List<LockForKeyholder> Locks { get; set; } = [];

    }

}