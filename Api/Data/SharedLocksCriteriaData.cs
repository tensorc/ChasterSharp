using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class SharedLocksCriteriaData
    {
        /// <summary>
        /// An array of shared locks ids
        /// </summary>
        [JsonPropertyName("sharedLockIds")]
        public ICollection<string>? SharedLockIds { get; set; } = default!;
        /// <summary>
        /// Whether the request includes locks created by wearers
        /// </summary>
        [JsonPropertyName("includeKeyholderLocks")]
        public bool? IncludeKeyholderLocks { get; set; } = default!;

    }

}