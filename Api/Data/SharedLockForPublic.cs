using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class SharedLockForPublic
    {
        /// <summary>
        /// Duration mode
        /// </summary>
        [JsonPropertyName("durationMode")]
        [Required(AllowEmptyStrings = true)]
        [JsonConverter(typeof(CustomStringEnumConverter<SharedLockDurationMode>))]
        public SharedLockDurationMode DurationMode { get; set; } = default!;
        /// <summary>
        /// The shared lock id
        /// </summary>
        [JsonPropertyName("_id")]
        [Required(AllowEmptyStrings = true)]
        public string Id { get; set; } = default!;
        /// <summary>
        /// The minimum duration, in seconds
        /// </summary>
        [JsonPropertyName("minDuration")]
        public int MinDuration { get; set; } = default!;
        /// <summary>
        /// The maximum duration, in seconds
        /// </summary>
        [JsonPropertyName("maxDuration")]
        public int MaxDuration { get; set; } = default!;
        /// <summary>
        /// The calculated max limit duration
        /// </summary>
        [JsonPropertyName("calculatedMaxLimitDuration")]
        public int? CalculatedMaxLimitDuration { get; set; } = default!;
        /// <summary>
        /// The creator
        /// </summary>
        [JsonPropertyName("user")]
        [Required]
        public UserForPublic User { get; set; } = new();
        /// <summary>
        /// The Unsplash photo
        /// </summary>
        [JsonPropertyName("unsplashPhoto")]
        public UnsplashPhoto? UnsplashPhoto { get; set; } = default!;
        /// <summary>
        /// Extension configurations
        /// </summary>
        [JsonPropertyName("extensions")]
        [Required]
        public List<ExtensionConfigForPublic> Extensions { get; set; } = [];
        /// <summary>
        /// Created at
        /// </summary>
        [JsonPropertyName("createdAt")]
        [Required(AllowEmptyStrings = true)]
        public string CreatedAt { get; set; } = default!;
        /// <summary>
        /// Updated at
        /// </summary>
        [JsonPropertyName("updatedAt")]
        public string? UpdatedAt { get; set; } = default!;
        /// <summary>
        /// Deleted at
        /// </summary>
        [JsonPropertyName("deletedAt")]
        public string? DeletedAt { get; set; } = default!;
        /// <summary>
        /// Archived at
        /// </summary>
        [JsonPropertyName("archivedAt")]
        public string? ArchivedAt { get; set; } = default!;
        /// <summary>
        /// List of locks
        /// <br/>
        /// <br/>Only returned in shared locks endpoints
        /// </summary>
        [JsonPropertyName("locks")]
        public List<Lock>? Locks { get; set; } = default!;
        /// <summary>
        /// Whether the lock requires a password
        /// </summary>
        [JsonPropertyName("requirePassword")]
        public bool RequirePassword { get; set; } = default!;
        /// <summary>
        /// Password
        /// </summary>
        [JsonPropertyName("password")]
        public string? Password { get; set; } = default!;
        /// <summary>
        /// The maximum duration of the lock, in seconds
        /// <br/>
        /// <br/>After this duration, the wearer can release themself
        /// <br/>regardless of the timer or extension restrictions.
        /// </summary>
        [JsonPropertyName("maxLimitDuration")]
        public int? MaxLimitDuration { get; set; } = default!;
        /// <summary>
        /// The minimum date
        /// </summary>
        [JsonPropertyName("minDate")]
        public DateTimeOffset? MinDate { get; set; } = default!;
        /// <summary>
        /// The maximum date
        /// </summary>
        [JsonPropertyName("maxDate")]
        public DateTimeOffset? MaxDate { get; set; } = default!;
        /// <summary>
        /// The maximum date of the lock
        /// <br/>
        /// <br/>After this date, the wearer can release themself
        /// <br/>regardless of the timer or extension restrictions.
        /// </summary>
        [JsonPropertyName("maxLimitDate")]
        public DateTimeOffset? MaxLimitDate { get; set; } = default!;
        /// <summary>
        /// Whether the remaining time should be displayed to the wearer
        /// </summary>
        [JsonPropertyName("displayRemainingTime")]
        public bool DisplayRemainingTime { get; set; } = default!;
        /// <summary>
        /// Whether the lock is limited in time
        /// </summary>
        [JsonPropertyName("limitLockTime")]
        public bool LimitLockTime { get; set; } = default!;
        /// <summary>
        /// The number of maximum locked users for this shared lock
        /// </summary>
        [JsonPropertyName("maxLockedUsers")]
        public int? MaxLockedUsers { get; set; } = default!;
        /// <summary>
        /// Whether the lock is public
        /// </summary>
        [JsonPropertyName("isPublic")]
        public bool IsPublic { get; set; } = default!;
        /// <summary>
        /// Whether the shared lock requires contact from wearer
        /// <br/>
        /// <br/>Displayed for information purposes only on the lock page
        /// </summary>
        [JsonPropertyName("requireContact")]
        public bool RequireContact { get; set; } = default!;
        /// <summary>
        /// The name
        /// </summary>
        [JsonPropertyName("name")]
        [Required(AllowEmptyStrings = true)]
        public string Name { get; set; } = default!;
        /// <summary>
        /// The description
        /// </summary>
        [JsonPropertyName("description")]
        [Required(AllowEmptyStrings = true)]
        public string Description { get; set; } = default!;
        /// <summary>
        /// Whether the time information should be hidden from the history
        /// </summary>
        [JsonPropertyName("hideTimeLogs")]
        public bool HideTimeLogs { get; set; } = default!;
        /// <summary>
        /// Whether the lock is findom
        /// </summary>
        [JsonPropertyName("isFindom")]
        public bool IsFindom { get; set; } = default!;
        /// <summary>
        /// Last saved at
        /// </summary>
        [JsonPropertyName("lastSavedAt")]
        [Required(AllowEmptyStrings = true)]
        public DateTimeOffset LastSavedAt { get; set; } = default!;

    }

}