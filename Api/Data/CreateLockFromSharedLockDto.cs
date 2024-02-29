using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class CreateLockFromSharedLockDto
    {
        /// <summary>
        /// The shared lock password, if needed
        /// </summary>
        [JsonPropertyName("password")]
        public string? Password { get; set; } = default!;
        /// <summary>
        /// The combination id
        /// </summary>
        [JsonPropertyName("combinationId")]
        [Required(AllowEmptyStrings = true)]
        public string CombinationId { get; set; } = default!;
        /// <summary>
        /// Whether the lock is a test lock and counts in the user stats
        /// <br/>Only available if the shared lock allows test locks
        /// </summary>
        [JsonPropertyName("isTestLock")]
        public bool IsTestLock { get; set; } = false;

    }

}