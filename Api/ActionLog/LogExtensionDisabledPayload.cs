using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class LogExtensionDisabledPayload
    {
        [JsonPropertyName("oldConfig")]
        public LogExtensionConfig OldConfig { get; set; } = new();

        /// <summary>
        /// The extension slug. 
        /// </summary>
        [JsonPropertyName("slug")]
        [Required(AllowEmptyStrings = true)]
        public string Slug { get; set; } = default!;
    }

}