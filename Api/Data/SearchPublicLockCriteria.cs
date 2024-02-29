using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class SearchPublicLockCriteria
    {
        [JsonPropertyName("duration")]
        [Required]
        public DurationCriteriaData Duration { get; set; } = new();
        [JsonPropertyName("extensions")]
        [Required]
        public ExtensionCriteriaData Extensions { get; set; } = new();
        /// <summary>
        /// Whether the lock is findom
        /// <br/>Set to null to return both findom and non-findom locks.
        /// </summary>
        [JsonPropertyName("isFindom")]
        [Required]
        public IsFindomCriteriaData IsFindom { get; set; } = new();

    }

}