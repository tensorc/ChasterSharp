using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class FavoriteSharedLocksRepDto
    {
        [JsonPropertyName("results")]
        [Required]
        public List<PublicLockForSearch> Results { get; set; } = [];
        [JsonPropertyName("lastId")]
        [Required(AllowEmptyStrings = true)]
        public string LastId { get; set; } = default!;
        [JsonPropertyName("hasMore")]
        public bool HasMore { get; set; } = default!;
        [JsonPropertyName("count")]
        public int Count { get; set; } = default!;

    }

}