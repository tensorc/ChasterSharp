using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class UserForPublic
    {
        /// <summary>
        /// The role
        /// </summary>
        [JsonPropertyName("role")]
        [Required(AllowEmptyStrings = true)]
        [JsonConverter(typeof(CustomStringEnumConverter<UserRole>))]
        public UserRole Role { get; set; } = default!;
        /// <summary>
        /// Enabled features
        /// </summary>
        [JsonPropertyName("features")]
        [Required]
        [JsonConverter(typeof(CustomICollectionStringEnumConverter<FeatureSwitch>))]
        public ICollection<FeatureSwitch> Features { get; set; } = new Collection<FeatureSwitch>();
        /// <summary>
        /// The user id
        /// </summary>
        [JsonPropertyName("_id")]
        [Required(AllowEmptyStrings = true)]
        public string Id { get; set; } = default!;
        /// <summary>
        /// The username
        /// </summary>
        [JsonPropertyName("username")]
        [Required(AllowEmptyStrings = true)]
        public string Username { get; set; } = default!;
        /// <summary>
        /// Whether the user has a Premium subscription
        /// </summary>
        [JsonPropertyName("isPremium")]
        public bool IsPremium { get; set; } = default!;
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
        [Required(AllowEmptyStrings = true)]
        public string Gender { get; set; } = default!;
        /// <summary>
        /// The age
        /// </summary>
        [JsonPropertyName("age")]
        public int? Age { get; set; } = default!;
        /// <summary>
        /// Whether the user is a findom
        /// </summary>
        [JsonPropertyName("isFindom")]
        public bool IsFindom { get; set; } = default!;
        /// <summary>
        /// The avatar URL
        /// </summary>
        [JsonPropertyName("avatarUrl")]
        [Required(AllowEmptyStrings = true)]
        public Uri? AvatarUrl { get; set; } = default!;
        /// <summary>
        /// Whether the user is online
        /// </summary>
        [JsonPropertyName("online")]
        public bool Online { get; set; } = default!;
        /// <summary>
        /// User last seen, in seconds
        /// </summary>
        [JsonPropertyName("lastSeen")]
        public int? LastSeen { get; set; } = default!;
        /// <summary>
        /// Whether the user is an admin
        /// </summary>
        [JsonPropertyName("isAdmin")]
        public bool IsAdmin { get; set; } = default!;
        /// <summary>
        /// Whether the user is a moderator
        /// </summary>
        [JsonPropertyName("isModerator")]
        public bool IsModerator { get; set; } = default!;
        /// <summary>
        /// User metadata
        /// </summary>
        [JsonPropertyName("metadata")]
        [Required]
        public UserMetadata Metadata { get; set; } = new();
        /// <summary>
        /// User full location
        /// </summary>
        [JsonPropertyName("fullLocation")]
        [Required(AllowEmptyStrings = true)]
        public string FullLocation { get; set; } = default!;
        /// <summary>
        /// The Discord ID
        /// </summary>
        [JsonPropertyName("discordId")]
        public string? DiscordId { get; set; } = default!;
        /// <summary>
        /// The Discord username
        /// </summary>
        [JsonPropertyName("discordUsername")]
        public string? DiscordUsername { get; set; } = default!;
        /// <summary>
        /// Whether the user is disabled
        /// </summary>
        [JsonPropertyName("isDisabled")]
        public bool IsDisabled { get; set; } = default!;
        /// <summary>
        /// Whether the user is suspended by the Chaster team
        /// </summary>
        [JsonPropertyName("isSuspended")]
        public bool IsSuspended { get; set; } = default!;
        /// <summary>
        /// Joined date (year and month, YYYY-MM)
        /// </summary>
        [JsonPropertyName("joinedAt")]
        [Required(AllowEmptyStrings = true)]
        public string JoinedAt { get; set; } = default!;
        /// <summary>
        /// Whether the user is a new member
        /// </summary>
        [JsonPropertyName("isNewMember")]
        public bool IsNewMember { get; set; } = default!;
        /// <summary>
        /// Whether the user is suspended or disabled
        /// </summary>
        [JsonPropertyName("isSuspendedOrDisabled")]
        public bool IsSuspendedOrDisabled { get; set; } = default!;

    }

}