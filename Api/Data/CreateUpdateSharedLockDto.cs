using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class CreateUpdateSharedLockDto
    {
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
        /// Whether the lock is public
        /// </summary>
        [JsonPropertyName("isPublic")]
        public bool IsPublic { get; set; } = default!;
        /// <summary>
        /// The number of maximum locked users for this shared lock
        /// </summary>
        [JsonPropertyName("maxLockedUsers")]
        public int? MaxLockedUsers { get; set; } = default!;
        /// <summary>
        /// An optional password
        /// </summary>
        [JsonPropertyName("password")]
        public string? Password { get; set; } = default!;
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
        [StringLength(60)]
        public string Name { get; set; } = default!;
        /// <summary>
        /// The description
        /// </summary>
        [JsonPropertyName("description")]
        [Required(AllowEmptyStrings = true)]
        public string Description { get; set; } = default!;
        /// <summary>
        /// The Unsplash photo id
        /// </summary>
        [JsonPropertyName("photoId")]
        [Required(AllowEmptyStrings = true)]
        public string PhotoId { get; set; } = default!;
        /// <summary>
        /// Whether the time information should be hidden from the history
        /// </summary>
        [JsonPropertyName("hideTimeLogs")]
        public bool HideTimeLogs { get; set; } = default!;
        /// <summary>
        /// Whether the lock is a findom lock
        /// </summary>
        [JsonPropertyName("isFindom")]
        public bool IsFindom { get; set; } = false;

        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; } = [];
    }

}