using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class LockHistoryDto
    {
        /// <summary>
        /// If provided, filter by extension slug
        /// </summary>
        [JsonPropertyName("extension")]
        public string? Extension { get; set; } = default!;
        /// <summary>
        /// Limit
        /// </summary>
        [JsonPropertyName("limit")]
        [Range(0D, 100D)]
        public int? Limit { get; set; } = default!;
        /// <summary>
        /// Offset lastId
        /// </summary>
        [JsonPropertyName("lastId")]
        public string? LastId { get; set; } = default!;

    }

}