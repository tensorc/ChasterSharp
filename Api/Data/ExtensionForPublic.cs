using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class ExtensionForPublic
    {
        /// <summary>
        /// The extension configuration. 
        /// </summary>
        [JsonPropertyName("defaultConfig")]
        [Required]
        public JsonElement DefaultConfig { get; set; } = default!;
        [JsonPropertyName("partnerExtensionId")]
        public string? PartnerExtensionId { get; set; } = default!;
        [JsonPropertyName("configIframeUrl")]
        public Uri? ConfigIframeUrl { get; set; } = default!;
        [JsonPropertyName("isTesting")]
        public bool IsTesting { get; set; } = default!;
        [JsonPropertyName("isPartner")]
        public bool IsPartner { get; set; } = default!;
        [JsonPropertyName("isDevelopedByCommunity")]
        public bool IsDevelopedByCommunity { get; set; } = default!;
        [JsonPropertyName("owner")]
        public ExtensionOwnerForPublic? Owner { get; set; } = default!;
        /// <summary>
        /// The extension subtitle
        /// </summary>
        [JsonPropertyName("subtitle")]
        [Required(AllowEmptyStrings = true)]
        public string Subtitle { get; set; } = default!;
        /// <summary>
        /// The extension summary
        /// </summary>
        [JsonPropertyName("summary")]
        [Required(AllowEmptyStrings = true)]
        public string Summary { get; set; } = default!;
        /// <summary>
        /// The name displayed to the end users
        /// </summary>
        [JsonPropertyName("displayName")]
        [Required(AllowEmptyStrings = true)]
        public string DisplayName { get; set; } = default!;
        /// <summary>
        /// The extension icon
        /// </summary>
        [JsonPropertyName("icon")]
        [Required(AllowEmptyStrings = true)]
        public string Icon { get; set; } = default!;
        /// <summary>
        /// The extension slug
        /// </summary>
        [JsonPropertyName("slug")]
        [Required(AllowEmptyStrings = true)]
        public string Slug { get; set; } = default!;
        /// <summary>
        /// Available modes
        /// </summary>
        [JsonPropertyName("availableModes")]
        [Required]
        [JsonConverter(typeof(CustomICollectionStringEnumConverter<LockExtensionMode>))]
        public ICollection<LockExtensionMode> AvailableModes { get; set; } = new Collection<LockExtensionMode>();
        /// <summary>
        /// Default regularity
        /// </summary>
        [JsonPropertyName("defaultRegularity")]
        public int DefaultRegularity { get; set; } = 3600;
        /// <summary>
        /// TWhether the extension is enabled
        /// </summary>
        [JsonPropertyName("isEnabled")]
        public bool IsEnabled { get; set; } = true;
        /// <summary>
        /// Whether the extension is only available to Premium users
        /// </summary>
        [JsonPropertyName("isPremium")]
        public bool IsPremium { get; set; } = false;
        /// <summary>
        /// Whether the extension is displayed by default in the list
        /// </summary>
        [JsonPropertyName("isFeatured")]
        public bool IsFeatured { get; set; } = false;
        /// <summary>
        /// Whether the extension is counted in the extensions limit
        /// </summary>
        [JsonPropertyName("isCountedInExtensionsLimit")]
        public bool IsCountedInExtensionsLimit { get; set; } = true;
        /// <summary>
        /// Whether the extension has actions
        /// </summary>
        [JsonPropertyName("hasActions")]
        public bool HasActions { get; set; } = true;

        public ExtensionSlug GetExtensionSlug()
        {
            return (ExtensionSlug)EnumStringConverter.GetEnumFromMemberValue(typeof(ExtensionSlug), Slug);
        }

    }

}