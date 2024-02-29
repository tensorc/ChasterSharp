using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class KeyholderSearchLocksDto
    {
        /// <summary>
        /// Search criteria
        /// </summary>
        [JsonPropertyName("criteria")]
        public KeyholderSearchLocksCriteria? Criteria { get; set; } = default!;
        /// <summary>
        /// Filter by lock status
        /// </summary>
        [JsonPropertyName("status")]
        [JsonConverter(typeof(CustomStringEnumConverter<KeyholderSearchLocksDtoStatus>))]
        public KeyholderSearchLocksDtoStatus? Status { get; set; } = default!;
        /// <summary>
        /// Search by username of shared lock name
        /// <br/>Min. 2 characters
        /// </summary>
        [JsonPropertyName("search")]
        public string? Search { get; set; } = default!;
        /// <summary>
        /// Page number (starts with 0)
        /// </summary>
        [JsonPropertyName("page")]
        public int? Page { get; set; } = default!;
        /// <summary>
        /// Number of items returned
        /// </summary>
        [JsonPropertyName("limit")]
        [Range(1, 50)]
        public int? Limit { get; set; } = default!;

    }

}