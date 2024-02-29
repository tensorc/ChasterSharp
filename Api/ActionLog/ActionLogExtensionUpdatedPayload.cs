using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class ActionLogExtensionUpdatedPayload
    {
        [JsonPropertyName("oldConfig")]
        public ActionLogExtensionConfig OldConfig { get; set; } = new();

        [JsonPropertyName("newConfig")]
        public ActionLogExtensionConfig NewConfig { get; set; } = new();

        /// <summary>
        /// The extension slug. 
        /// </summary>
        [JsonPropertyName("slug")]
        [Required(AllowEmptyStrings = true)]
        public string Slug { get; set; } = default!;
    }

}