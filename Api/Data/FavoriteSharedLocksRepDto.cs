using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class FavoriteSharedLocksRepDto
    {
        [JsonPropertyName("results")]
        [Required]
        public ICollection<PublicLockForSearch> Results { get; set; } = new Collection<PublicLockForSearch>();
        [JsonPropertyName("lastId")]
        [Required(AllowEmptyStrings = true)]
        public string LastId { get; set; } = default!;
        [JsonPropertyName("hasMore")]
        public bool HasMore { get; set; } = default!;
        [JsonPropertyName("count")]
        public int Count { get; set; } = default!;

    }

}