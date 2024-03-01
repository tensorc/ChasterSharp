using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class SearchPublicLockRepDto
    {
        [JsonPropertyName("count")]
        public int Count { get; set; } = default!;
        [JsonPropertyName("hasMore")]
        public bool HasMore { get; set; } = default!;
        [JsonPropertyName("results")]
        [Required]
        public List<PublicLockForSearch> Results { get; set; } = new();

    }

}