using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class ExploreCategoryForPublic
    {
        [JsonPropertyName("_id")]
        [Required(AllowEmptyStrings = true)]
        public string Id { get; set; } = default!;
        [JsonPropertyName("locks")]
        [Required]
        public ICollection<PublicLockForSearch> Locks { get; set; } = new Collection<PublicLockForSearch>();
        [JsonPropertyName("description")]
        [Required(AllowEmptyStrings = true)]
        public string Description { get; set; } = default!;
        [JsonPropertyName("featured")]
        public bool Featured { get; set; } = default!;
        [JsonPropertyName("nbItems")]
        public int? NbItems { get; set; } = default!;
        [JsonPropertyName("order")]
        public int Order { get; set; } = default!;
        [JsonPropertyName("title")]
        [Required(AllowEmptyStrings = true)]
        public string Title { get; set; } = default!;
        [JsonPropertyName("type")]
        [Required(AllowEmptyStrings = true)]
        public string Type { get; set; } = default!;

    }

}