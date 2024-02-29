using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class KeyholderSearchLocksCriteria
    {
        [JsonPropertyName("sharedLocks")]
        public SharedLocksCriteriaData? SharedLocks { get; set; } = default!;

    }

}