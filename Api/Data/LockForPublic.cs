using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class LockForPublic
    {
        /// <summary>
        /// The status
        /// </summary>
        [JsonPropertyName("status")]
        [Required(AllowEmptyStrings = true)]
        [JsonConverter(typeof(CustomStringEnumConverter<LockStatus>))]
        public LockStatus Status { get; set; } = default!;
        /// <summary>
        /// The lock id
        /// </summary>
        [JsonPropertyName("_id")]
        [Required(AllowEmptyStrings = true)]
        public string Id { get; set; } = default!;
        /// <summary>
        /// The end date
        /// </summary>
        [JsonPropertyName("endDate")]
        public DateTimeOffset? EndDate { get; set; } = default!;
        /// <summary>
        /// The lock title
        /// </summary>
        [JsonPropertyName("title")]
        [Required(AllowEmptyStrings = true)]
        public string Title { get; set; } = default!;
        /// <summary>
        /// The total duration, since the creation of the lock
        /// </summary>
        [JsonPropertyName("totalDuration")]
        public int TotalDuration { get; set; } = default!;
        /// <summary>
        /// The user
        /// </summary>
        [JsonPropertyName("user")]
        [Required]
        public UserForPublic User { get; set; } = new();
        /// <summary>
        /// The keyholder
        /// </summary>
        [JsonPropertyName("keyholder")]
        public UserForPublic? Keyholder { get; set; } = default!;
        /// <summary>
        /// The shared lock
        /// </summary>
        [JsonPropertyName("sharedLock")]
        public SharedLockForPublic? SharedLock { get; set; } = default!;
        /// <summary>
        /// Whether the wearer is allowed to view the remaining time
        /// </summary>
        [JsonPropertyName("isAllowedToViewTime")]
        public bool IsAllowedToViewTime { get; set; } = default!;
        /// <summary>
        /// Whether the lock can be unlocked
        /// </summary>
        [JsonPropertyName("canBeUnlocked")]
        public bool CanBeUnlocked { get; set; } = default!;
        /// <summary>
        /// Whether the lock can be unlocked because the max limit date has been reached
        /// </summary>
        [JsonPropertyName("canBeUnlockedByMaxLimitDate")]
        public bool CanBeUnlockedByMaxLimitDate { get; set; } = default!;
        /// <summary>
        /// Whether the lock is frozen
        /// </summary>
        [JsonPropertyName("isFrozen")]
        public bool IsFrozen { get; set; } = default!;
        /// <summary>
        /// The user role
        /// </summary>
        [JsonPropertyName("role")]
        [Required(AllowEmptyStrings = true)]
        [JsonConverter(typeof(CustomStringEnumConverter<LockForPublicRole>))]
        public LockForPublicRole Role { get; set; } = default!;
        /// <summary>
        /// The extensions
        /// </summary>
        [JsonPropertyName("extensions")]
        [Required]
        public ICollection<ExtensionPartyForPublic> Extensions { get; set; } = new Collection<ExtensionPartyForPublic>();
        /// <summary>
        /// The combination
        /// </summary>
        [JsonPropertyName("combination")]
        [Required(AllowEmptyStrings = true)]
        public string Combination { get; set; } = default!;
        /// <summary>
        /// List of home actions
        /// </summary>
        [JsonPropertyName("availableHomeActions")]
        [Required]
        public ICollection<ExtensionHomeActionWithPartyId> AvailableHomeActions { get; set; } = new Collection<ExtensionHomeActionWithPartyId>();
        /// <summary>
        /// Reasons preventing unlocking
        /// </summary>
        [JsonPropertyName("reasonsPreventingUnlocking")]
        [Required]
        public ICollection<ReasonPreventingUnlocking> ReasonsPreventingUnlocking { get; set; } = new Collection<ReasonPreventingUnlocking>();
        /// <summary>
        /// Whether the extensions allow unlocking
        /// </summary>
        [JsonPropertyName("extensionsAllowUnlocking")]
        public bool ExtensionsAllowUnlocking { get; set; } = default!;
        /// <summary>
        /// The last verification picture
        /// </summary>
        [JsonPropertyName("lastVerificationPicture")]
        public VerificationPictureItem? LastVerificationPicture { get; set; } = default!;
        /// <summary>
        /// Created at
        /// </summary>
        [JsonPropertyName("createdAt")]
        [Required(AllowEmptyStrings = true)]
        public DateTimeOffset CreatedAt { get; set; } = default!;
        /// <summary>
        /// Updated at
        /// </summary>
        [JsonPropertyName("updatedAt")]
        [Required(AllowEmptyStrings = true)]
        public DateTimeOffset UpdatedAt { get; set; } = default!;
        /// <summary>
        /// The start date
        /// </summary>
        [JsonPropertyName("startDate")]
        [Required(AllowEmptyStrings = true)]
        public DateTimeOffset StartDate { get; set; } = default!;
        /// <summary>
        /// The minimum initial date configured at creation
        /// </summary>
        [JsonPropertyName("minDate")]
        [Required(AllowEmptyStrings = true)]
        public DateTimeOffset MinDate { get; set; } = default!;
        /// <summary>
        /// The maximum initial date configured at creation
        /// </summary>
        [JsonPropertyName("maxDate")]
        [Required(AllowEmptyStrings = true)]
        public DateTimeOffset MaxDate { get; set; } = default!;
        /// <summary>
        /// The maximum date of the lock
        /// <br/>
        /// <br/>After this date, the wearer can release themself
        /// <br/>regardless of the timer or extension restrictions.
        /// </summary>
        [JsonPropertyName("maxLimitDate")]
        public DateTimeOffset? MaxLimitDate { get; set; } = default!;
        /// <summary>
        /// Whether the remaining time is displayed to the wearer
        /// </summary>
        [JsonPropertyName("displayRemainingTime")]
        public bool DisplayRemainingTime { get; set; } = default!;
        /// <summary>
        /// Whether the lock is limited in duration
        /// </summary>
        [JsonPropertyName("limitLockTime")]
        public bool LimitLockTime { get; set; } = default!;
        /// <summary>
        /// Deleted at
        /// </summary>
        [JsonPropertyName("deletedAt")]
        public DateTimeOffset? DeletedAt { get; set; } = default!;
        /// <summary>
        /// Unlocked at
        /// </summary>
        [JsonPropertyName("unlockedAt")]
        public DateTimeOffset? UnlockedAt { get; set; } = default!;
        /// <summary>
        /// Archived at
        /// </summary>
        [JsonPropertyName("archivedAt")]
        public DateTimeOffset? ArchivedAt { get; set; } = default!;
        /// <summary>
        /// Frozen at
        /// </summary>
        [JsonPropertyName("frozenAt")]
        public DateTimeOffset? FrozenAt { get; set; } = default!;
        /// <summary>
        /// Keyholder archived at
        /// </summary>
        [JsonPropertyName("keyholderArchivedAt")]
        public DateTimeOffset? KeyholderArchivedAt { get; set; } = default!;
        /// <summary>
        /// Whether the lock allows session offers
        /// </summary>
        [JsonPropertyName("allowSessionOffer")]
        public bool AllowSessionOffer { get; set; } = default!;
        /// <summary>
        /// Whether the lock is a test lock and counts in the user stats
        /// </summary>
        [JsonPropertyName("isTestLock")]
        public bool IsTestLock { get; set; } = default!;
        /// <summary>
        /// The offer token
        /// </summary>
        [JsonPropertyName("offerToken")]
        public string? OfferToken { get; set; } = default!;
        /// <summary>
        /// True if the time information should be hidden from the history
        /// </summary>
        [JsonPropertyName("hideTimeLogs")]
        public bool HideTimeLogs { get; set; } = default!;
        /// <summary>
        /// Whether the keyholder is trusted
        /// </summary>
        [JsonPropertyName("trusted")]
        public bool Trusted { get; set; } = default!;

    }

}