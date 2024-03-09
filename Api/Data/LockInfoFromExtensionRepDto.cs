using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class LockInfoFromExtensionRepDto
    {
        /// <summary>
        /// The extension configuration. 
        /// </summary>
        [JsonPropertyName("extension")]
        [Required]
        public JsonElement Extension { get; set; } = default!;
        /// <summary>
        /// The lock
        /// </summary>
        [JsonPropertyName("lock")]
        [Required]
        public Lock Lock { get; set; } = new();

    }

}