using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class MessagesRepDto
    {
        /// <summary>
        /// List of messages
        /// </summary>
        [JsonPropertyName("results")]
        [Required]
        public List<MessageForPublic> Results { get; set; } = new();
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