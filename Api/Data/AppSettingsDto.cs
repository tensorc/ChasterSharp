using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class AppSettingsDto
    {
        /// <summary>
        /// Global features
        /// </summary>
        [JsonPropertyName("features")]
        [Required]
        [JsonConverter(typeof(CustomICollectionStringEnumConverter<FeatureSwitch>))]
        public ICollection<FeatureSwitch> Features { get; set; } = new Collection<FeatureSwitch>();
        /// <summary>
        /// The maximum number of locks allowed for a non-premium user
        /// </summary>
        [JsonPropertyName("nonPremiumMaxLocks")]
        public int NonPremiumMaxLocks { get; set; } = default!;
        /// <summary>
        /// The maximum number of extensions allowed for a non-premium user
        /// </summary>
        [JsonPropertyName("nonPremiumMaxExtensions")]
        public int NonPremiumMaxExtensions { get; set; } = default!;
        /// <summary>
        /// Maximum number of attachments per upload
        /// </summary>
        [JsonPropertyName("maxAttachments")]
        public int MaxAttachments { get; set; } = default!;
        /// <summary>
        /// True if the instance requires an access key
        /// </summary>
        [JsonPropertyName("registerRequiresAccessKey")]
        public bool RegisterRequiresAccessKey { get; set; } = default!;
        /// <summary>
        /// The recaptcha client key
        /// </summary>
        [JsonPropertyName("recaptchaClientKey")]
        [Required(AllowEmptyStrings = true)]
        public string RecaptchaClientKey { get; set; } = default!;
        /// <summary>
        /// The server time
        /// </summary>
        [JsonPropertyName("time")]
        [Required(AllowEmptyStrings = true)]
        public DateTimeOffset Time { get; set; } = default!;
        /// <summary>
        /// The app version
        /// </summary>
        [JsonPropertyName("version")]
        [Required(AllowEmptyStrings = true)]
        public string Version { get; set; } = default!;
        /// <summary>
        /// Community event settings
        /// </summary>
        [JsonPropertyName("communityEvent")]
        public CommunityEventSettings? CommunityEvent { get; set; } = default!;
        /// <summary>
        /// Stripe public key
        /// </summary>
        [JsonPropertyName("stripePublicKey")]
        [Required(AllowEmptyStrings = true)]
        public string StripePublicKey { get; set; } = default!;
        /// <summary>
        /// Vapid public key
        /// </summary>
        [JsonPropertyName("vapidPublicKey")]
        [Required(AllowEmptyStrings = true)]
        public string VapidPublicKey { get; set; } = default!;

    }

}