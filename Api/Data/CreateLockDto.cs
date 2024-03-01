using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class CreateLockDto
    {
        /// <summary>
        /// Min duration in seconds
        /// </summary>
        [JsonPropertyName("minDuration")] 
        public int MinDuration { get; set; } = default!;
        /// <summary>
        /// Max duration in seconds
        /// </summary>
        [JsonPropertyName("maxDuration")]
        public int MaxDuration { get; set; } = default!;
        /// <summary>
        /// Max limit duration in seconds
        /// </summary>
        [JsonPropertyName("maxLimitDuration")]
        public int? MaxLimitDuration { get; set; } = default!;
        /// <summary>
        /// True if the user can view the remaining time
        /// </summary>
        [JsonPropertyName("displayRemainingTime")]
        public bool DisplayRemainingTime { get; set; } = default!;
        /// <summary>
        /// True if the lock is limited in duration
        /// </summary>
        [JsonPropertyName("limitLockTime")]
        public bool LimitLockTime { get; set; } = default!;
        /// <summary>
        /// The combination id
        /// <br/>
        /// <br/>A combination object can be created by using the combination endpoints.
        /// </summary>
        [JsonPropertyName("combinationId")]
        [Required(AllowEmptyStrings = true)]
        public string CombinationId { get; set; } = default!;
        [JsonPropertyName("extensions")]
        [Required]
        public List<LockExtensionConfigDto> Extensions { get; set; } = new();
        /// <summary>
        /// True if the wearer can offer the lock to a keyholder
        /// </summary>
        [JsonPropertyName("allowSessionOffer")]
        public bool AllowSessionOffer { get; set; } = default!;
        /// <summary>
        /// Whether the lock is a test lock and counts in the user stats
        /// </summary>
        [JsonPropertyName("isTestLock")]
        public bool IsTestLock { get; set; } = false;
        /// <summary>
        /// True if the time information should be hidden from the history
        /// </summary>
        [JsonPropertyName("hideTimeLogs")]
        public bool HideTimeLogs { get; set; } = default!;

    }

}