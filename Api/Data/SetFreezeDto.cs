using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class SetFreezeDto
    {
        /// <summary>
        /// Whether the lock is frozen
        /// </summary>
        [JsonPropertyName("isFrozen")]
        public bool IsFrozen { get; set; } 

    }

}