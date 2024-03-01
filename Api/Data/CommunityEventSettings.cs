using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class CommunityEventSettings
    {
        /// <summary>
        /// Whether the community event is enabled
        /// </summary>
        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; } = default!;
        /// <summary>
        /// The community event slug
        /// </summary>
        [JsonPropertyName("slug")]
        [Required(AllowEmptyStrings = true)]
        public string Slug { get; set; } = default!;
        /// <summary>
        /// The community event name
        /// </summary>
        [JsonPropertyName("name")]
        [Required(AllowEmptyStrings = true)]
        public string Name { get; set; } = default!;
        /// <summary>
        /// The community event color
        /// </summary>
        [JsonPropertyName("color")]
        [Required(AllowEmptyStrings = true)]
        public string Color { get; set; } = default!;
        /// <summary>
        /// The community event light color
        /// </summary>
        [JsonPropertyName("lightColor")]
        [Required(AllowEmptyStrings = true)]
        public string LightColor { get; set; } = default!;
        /// <summary>
        /// The community event icon
        /// </summary>
        [JsonPropertyName("icon")]
        [Required(AllowEmptyStrings = true)]
        public string Icon { get; set; } = default!;
        /// <summary>
        /// The community event tiers
        /// </summary>
        [JsonPropertyName("tiers")]
        [Required]
        public List<CommunityEventTier> Tiers { get; set; } = [];

    }

}