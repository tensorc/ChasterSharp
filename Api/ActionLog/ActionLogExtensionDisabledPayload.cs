using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class ActionLogExtensionDisabledPayload
    {
        [JsonPropertyName("oldConfig")]
        public ActionLogExtensionConfig OldConfig { get; set; } = new();

        /// <summary>
        /// The extension slug. 
        /// </summary>
        [JsonPropertyName("slug")]
        [Required(AllowEmptyStrings = true)]
        public string Slug { get; set; } = default!;
    }

}