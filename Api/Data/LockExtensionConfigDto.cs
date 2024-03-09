using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class LockExtensionConfigDto
    {
        /// <summary>
        /// The extension slug. 
        /// </summary>
        [JsonPropertyName("slug")]
        [Required(AllowEmptyStrings = true)]
        public string Slug { get; set; } = default!;
        /// <summary>
        /// The extension configuration. 
        /// </summary>
        [JsonPropertyName("config")]
        [Required]
        public JsonElement Config { get; set; } = default!;
        [JsonPropertyName("partnerConfigurationToken")]
        public string? PartnerConfigurationToken { get; set; }

        [JsonPropertyName("mode")]
        [Required(AllowEmptyStrings = true)]
        [JsonConverter(typeof(CustomStringEnumConverter<LockExtensionMode>))]
        public LockExtensionMode Mode { get; set; } = LockExtensionMode.Unlimited;

        [JsonPropertyName("regularity")] 
        public int Regularity { get; set; } = 3600;

        public ExtensionSlug GetExtensionSlug()
        {
            return (ExtensionSlug)EnumStringConverter.GetEnumFromMemberValue(typeof(ExtensionSlug), Slug);
        }

    }

}