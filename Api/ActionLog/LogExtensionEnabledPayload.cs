using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class LogExtensionEnabledPayload
    {
        [JsonPropertyName("newConfig")]
        public LogExtensionConfig NewConfig { get; set; } = new();

        /// <summary>
        /// The extension slug. 
        /// </summary>
        [JsonPropertyName("slug")]
        [Required(AllowEmptyStrings = true)]
        public string Slug { get; set; } = default!;
    }

}