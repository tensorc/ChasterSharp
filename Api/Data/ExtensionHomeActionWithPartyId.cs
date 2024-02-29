using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class ExtensionHomeActionWithPartyId
    {
        [JsonPropertyName("extensionPartyId")]
        [Required(AllowEmptyStrings = true)]
        public string ExtensionPartyId { get; set; } = default!;
        /// <summary>
        /// An identifier that is returned to the extension when the user navigates to the extension page.
        /// </summary>
        [JsonPropertyName("slug")]
        [Required(AllowEmptyStrings = true)]
        public string Slug { get; set; } = default!;
        /// <summary>
        /// The title displayed on the list item for the action.
        /// </summary>
        [JsonPropertyName("title")]
        [Required(AllowEmptyStrings = true)]
        public string Title { get; set; } = default!;
        /// <summary>
        /// The description displayed on the list item for the action.
        /// </summary>
        [JsonPropertyName("description")]
        [Required(AllowEmptyStrings = true)]
        public string Description { get; set; } = default!;
        /// <summary>
        /// The icon associated with the action, which must be one of the valid FontAwesome 5 icons.
        /// </summary>
        [JsonPropertyName("icon")]
        [Required(AllowEmptyStrings = true)]
        public string Icon { get; set; } = default!;
        /// <summary>
        /// Displays a small badge on the list item, useful for indicating notifications or counts associated with the action (e.g., the number of tasks to do or remaining actions in the extension).
        /// </summary>
        [JsonPropertyName("badge")]
        public string? Badge { get; set; } = default!;

    }

}