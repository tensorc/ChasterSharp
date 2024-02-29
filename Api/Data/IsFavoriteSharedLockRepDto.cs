using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class IsFavoriteSharedLockRepDto
    {
        /// <summary>
        /// Whether the lock is user favorite
        /// </summary>
        [JsonPropertyName("favorite")]
        public bool Favorite { get; set; } = default!;

    }

}