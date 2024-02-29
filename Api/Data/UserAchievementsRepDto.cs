using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class UserAchievementsRepDto
    {
        [JsonPropertyName("slug")]
        [Required(AllowEmptyStrings = true)]
        public string Slug { get; set; } = default!;
        [JsonPropertyName("granted")]
        public bool Granted { get; set; } = default!;
        [JsonPropertyName("progress")]
        public int? Progress { get; set; } = default!;
        [JsonPropertyName("total")]
        public int? Total { get; set; } = default!;
        [JsonPropertyName("grantedAt")]
        public string? GrantedAt { get; set; } = default!;
        [JsonPropertyName("name")]
        [Required(AllowEmptyStrings = true)]
        public string Name { get; set; } = default!;
        [JsonPropertyName("description")]
        [Required(AllowEmptyStrings = true)]
        public string Description { get; set; } = default!;
        [JsonPropertyName("category")]
        [Required(AllowEmptyStrings = true)]
        public string Category { get; set; } = default!;
        [JsonPropertyName("progressEnabled")]
        public bool ProgressEnabled { get; set; } = default!;
        [JsonPropertyName("hideIfNotGranted")]
        public bool HideIfNotGranted { get; set; } = default!;

    }

}