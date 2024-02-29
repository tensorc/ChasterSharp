using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class CommunityEventAction
    {
        [JsonPropertyName("name")]
        [Required(AllowEmptyStrings = true)]
        public string Name { get; set; } = default!;
        [JsonPropertyName("title")]
        [Required(AllowEmptyStrings = true)]
        public string Title { get; set; } = default!;
        [JsonPropertyName("description")]
        public string? Description { get; set; } = default!;
        [JsonPropertyName("points")]
        public int Points { get; set; } = default!;
        [JsonPropertyName("maxPerPeriod")]
        public int? MaxPerPeriod { get; set; } = default!;
        [JsonPropertyName("group")]
        public string? Group { get; set; } = default!;

    }

}