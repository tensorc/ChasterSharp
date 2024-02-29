using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class LastMessageForPublic
    {
        [JsonPropertyName("_id")]
        [Required(AllowEmptyStrings = true)]
        public string Id { get; set; } = default!;
        /// <summary>
        /// The message content
        /// </summary>
        [JsonPropertyName("message")]
        [Required(AllowEmptyStrings = true)]
        public string Message { get; set; } = default!;

    }

}