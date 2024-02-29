using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class IsFindomCriteriaData
    {
        /// <summary>
        /// Whether the lock is findom
        /// <br/>If true, return only findom locks.
        /// <br/>If false, return only non-findom locks.
        /// </summary>
        [JsonPropertyName("isFindom")]
        public bool IsFindom { get; set; } = default!;

    }

}