using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class MessageForPublic
    {
        /// <summary>
        /// The message id
        /// </summary>
        [JsonPropertyName("_id")]
        [Required(AllowEmptyStrings = true)]
        public string Id { get; set; } = default!;
        /// <summary>
        /// The sender id
        /// </summary>
        [JsonPropertyName("user")]
        [Required(AllowEmptyStrings = true)]
        public string User { get; set; } = default!;
        /// <summary>
        /// Message attachments
        /// </summary>
        [JsonPropertyName("attachments")]
        [Required]
        public ICollection<AppFileForPublic> Attachments { get; set; } = new Collection<AppFileForPublic>();
        /// <summary>
        /// The conversation id
        /// </summary>
        [JsonPropertyName("conversation")]
        [Required(AllowEmptyStrings = true)]
        public string Conversation { get; set; } = default!;
        /// <summary>
        /// Created at
        /// </summary>
        [JsonPropertyName("createdAt")]
        [Required(AllowEmptyStrings = true)]
        public DateTimeOffset CreatedAt { get; set; } = default!;
        /// <summary>
        /// Updated at
        /// </summary>
        [JsonPropertyName("updatedAt")]
        [Required(AllowEmptyStrings = true)]
        public DateTimeOffset UpdatedAt { get; set; } = default!;
        /// <summary>
        /// Nonce
        /// <br/>
        /// <br/>Is present only in the return of the websocket during the creation of the
        /// <br/>message, for the sender.
        /// </summary>
        [JsonPropertyName("nonce")]
        public string? Nonce { get; set; } = default!;
        /// <summary>
        /// The message type
        /// </summary>
        [JsonPropertyName("type")]
        [Required(AllowEmptyStrings = true)]
        [JsonConverter(typeof(CustomStringEnumConverter<MessageForPublicType>))]
        public MessageForPublicType Type { get; set; } = default!;
        /// <summary>
        /// The message content
        /// </summary>
        [JsonPropertyName("message")]
        [Required(AllowEmptyStrings = true)]
        public string Message { get; set; } = default!;

    }

}