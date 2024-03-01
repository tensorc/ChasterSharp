using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class ConversationsRepDto
    {
        /// <summary>
        /// List of conversations
        /// </summary>
        [JsonPropertyName("results")]
        [Required]
        public List<ConversationForPublic> Results { get; set; } = [];
        /// <summary>
        /// The number of results
        /// </summary>
        [JsonPropertyName("count")]
        public int Count { get; set; } = default!;
        /// <summary>
        /// Has more
        /// </summary>
        [JsonPropertyName("hasMore")]
        public bool HasMore { get; set; } = default!;

    }

}