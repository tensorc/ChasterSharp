using System.Collections.ObjectModel;
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
        public ICollection<MessageForPublic> Results { get; set; } = new Collection<MessageForPublic>();
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