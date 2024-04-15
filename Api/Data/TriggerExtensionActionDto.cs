using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class TriggerExtensionActionDto
    {
        /// <summary>
        /// The action name
        /// <br/>Refer to the extension documentation to know the available actions
        /// </summary>
        [JsonPropertyName("action")]
        [Required(AllowEmptyStrings = true)]
        public string Action { get; set; } = default!;

        /// <summary>
        /// The action payload
        /// </summary>
        [JsonPropertyName("payload")]
        [Required]
        public JsonElement Payload { get; set; } = Util.EmptyJsonElement;

    }

}