using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class UpdateConversationDto
    {
        /// <summary>
        /// The file token
        /// <br/>
        /// <br/>Create a file token by using the `/files/upload` endpoint.
        /// </summary>
        [JsonPropertyName("attachments")]
        public string? Attachments { get; set; } = default!;
        /// <summary>
        /// The message
        /// </summary>
        [JsonPropertyName("message")]
        [Required(AllowEmptyStrings = true)]
        public string Message { get; set; } = default!;
        /// <summary>
        /// Nonce
        /// <br/>
        /// <br/>If this field is included, it will be returned to the websocket client
        /// </summary>
        [JsonPropertyName("nonce")]
        public string? Nonce { get; set; } = default!;

    }

}