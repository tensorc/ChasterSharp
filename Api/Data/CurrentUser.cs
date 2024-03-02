using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class CurrentUser
    {
        /// <summary>
        /// Enabled features
        /// </summary>
        [JsonPropertyName("features")]
        [Required]
        [JsonConverter(typeof(CustomListStringEnumConverter<FeatureSwitch>))]
        public List<FeatureSwitch> Features { get; set; } = [];
        /// <summary>
        /// The user id
        /// </summary>
        [JsonPropertyName("_id")]
        [Required(AllowEmptyStrings = true)]
        public string Id { get; set; } = default!;
        /// <summary>
        /// The avatar URL
        /// </summary>
        [JsonPropertyName("avatarUrl")]
        [Required(AllowEmptyStrings = true)]
        public Uri? AvatarUrl { get; set; } = default!;
        /// <summary>
        /// True if the user is a premium user
        /// </summary>
        [JsonPropertyName("isPremium")]
        public bool IsPremium { get; set; } = default!;
        [JsonPropertyName("needsDiscordMigration")]
        public bool NeedsDiscordMigration { get; set; } = default!;
        /// <summary>
        /// The user Keycloak id
        /// </summary>
        [JsonPropertyName("keycloakId")]
        [Required(AllowEmptyStrings = true)]
        public string KeycloakId { get; set; } = default!;
        /// <summary>
        /// The username
        /// </summary>
        [JsonPropertyName("username")]
        [Required(AllowEmptyStrings = true)]
        public string Username { get; set; } = default!;
        /// <summary>
        /// The email
        /// </summary>
        [JsonPropertyName("email")]
        [Required(AllowEmptyStrings = true)]
        public string Email { get; set; } = default!;
        /// <summary>
        /// End date of subscription
        /// </summary>
        [JsonPropertyName("subscriptionEnd")]
        public DateTimeOffset? SubscriptionEnd { get; set; } = default!;
        /// <summary>
        /// End date of custom subscription
        /// </summary>
        [JsonPropertyName("customSubscriptionEnd")]
        public DateTimeOffset? CustomSubscriptionEnd { get; set; } = default!;
        /// <summary>
        /// Whether the subscription is past due
        /// </summary>
        [JsonPropertyName("hasPastDueSubscription")]
        public bool HasPastDueSubscription { get; set; } = default!;
        /// <summary>
        /// The profile description
        /// </summary>
        [JsonPropertyName("description")]
        [Required(AllowEmptyStrings = true)]
        public string Description { get; set; } = default!;
        /// <summary>
        /// The location
        /// </summary>
        [JsonPropertyName("location")]
        [Required(AllowEmptyStrings = true)]
        public string Location { get; set; } = default!;
        /// <summary>
        /// The gender
        /// </summary>
        [JsonPropertyName("gender")]
        public string? Gender { get; set; } = default!;
        /// <summary>
        /// The birth date
        /// </summary>
        [JsonPropertyName("birthDate")]
        public DateTimeOffset? BirthDate { get; set; } = default!;
        /// <summary>
        /// The role
        /// </summary>
        [JsonPropertyName("role")]
        [Required(AllowEmptyStrings = true)]
        [JsonConverter(typeof(CustomStringEnumConverter<CurrentUserRole>))]
        public CurrentUserRole Role { get; set; } = default!;
        /// <summary>
        /// Whether the email is verified
        /// </summary>
        [JsonPropertyName("emailVerified")]
        public bool EmailVerified { get; set; } = default!;
        /// <summary>
        /// Whether the user is a developer
        /// </summary>
        [JsonPropertyName("isDeveloper")]
        public bool? IsDeveloper { get; set; } = default!;
        /// <summary>
        /// Whether the user is a moderator
        /// </summary>
        [JsonPropertyName("isModerator")]
        public bool? IsModerator { get; set; } = default!;

        /// <summary>
        /// Whether the subscription is canceled after the end date
        /// </summary>
        [JsonPropertyName("subscriptionCancelAfterEnd")]
        public bool? SubscriptionCancelAfterEnd { get; set; } = default!; //NOTE: The API says this is required but that doesn't seem to be the case

        /// <summary>
        /// The Discord id
        /// </summary>
        [JsonPropertyName("discordId")]
        public string? DiscordId { get; set; } = default!;
        /// <summary>
        /// The Discord username
        /// </summary>
        [JsonPropertyName("discordUsername")]
        public string? DiscordUsername { get; set; } = default!;
        /// <summary>
        /// Whether the user is an admin
        /// </summary>
        [JsonPropertyName("isAdmin")]
        public bool? IsAdmin { get; set; } = default!;
        /// <summary>
        /// Whether the user is a findom
        /// </summary>
        [JsonPropertyName("isFindom")]
        public bool IsFindom { get; set; } = default!;
        /// <summary>
        /// The user settings
        /// </summary>
        [JsonPropertyName("settings")]
        [Required]
        public UserSettings Settings { get; set; } = new();
        /// <summary>
        /// The user metadata
        /// </summary>
        [JsonPropertyName("metadata")]
        [Required]
        public UserMetadata Metadata { get; set; } = new();
        /// <summary>
        /// The country
        /// </summary>
        [JsonPropertyName("country")]
        public Country? Country { get; set; } = default!;
        /// <summary>
        /// Region
        /// </summary>
        [JsonPropertyName("region")]
        public Region? Region { get; set; } = default!;
        /// <summary>
        /// The user private metadata
        /// </summary>
        [JsonPropertyName("privateMetadata")]
        [Required]
        public UserPrivateMetadata PrivateMetadata { get; set; } = new();
        /// <summary>
        /// Whether the user has accepted the community rules
        /// </summary>
        [JsonPropertyName("hasAcceptedCommunityRules")]
        public bool HasAcceptedCommunityRules { get; set; } = default!;

    }

}