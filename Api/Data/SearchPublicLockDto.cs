using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class SearchPublicLockDto
    {
        [JsonPropertyName("criteria")]
        [Required]
        public SearchPublicLockCriteria Criteria { get; set; } = new();
        [JsonPropertyName("limit")]
        [Range(0, 100)]
        public int Limit { get; set; } = 15;
        [JsonPropertyName("lastId")]
        public string? LastId { get; set; } = default!;

    }

}