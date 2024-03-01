using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class CreateConversationDto
    {
        /// <summary>
        /// List of user ids in the conversation, excluding the logged user
        /// </summary>
        [JsonPropertyName("users")]
        [Required]
        public ICollection<string> Users { get; set; } = new Collection<string>();
        /// <summary>
        /// The conversation type
        /// <br/>
        /// <br/>The `group` type is currently not supported.
        /// </summary>
        [JsonPropertyName("type")]
        [Required(AllowEmptyStrings = true)]
        [JsonConverter(typeof(CustomStringEnumConverter<ConversationType>))]
        public ConversationType Type { get; set; } = default!;
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