using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class HistoryRepDto
    {
        /// <summary>
        /// List of action logs
        /// </summary>
        [JsonPropertyName("results")]
        [Required]
        public ICollection<ActionLogForPublic> Results { get; set; } = new Collection<ActionLogForPublic>();
        /// <summary>
        /// Number of total action logs
        /// </summary>
        [JsonPropertyName("count")]
        public int Count { get; set; } = default!;
        /// <summary>
        /// Has more results
        /// </summary>
        [JsonPropertyName("hasMore")]
        public bool HasMore { get; set; } = default!;
    }

}