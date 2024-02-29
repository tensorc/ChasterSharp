using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class ConversationForPublic
    {
        /// <summary>
        /// The conversation id
        /// </summary>
        [JsonPropertyName("_id")]
        [Required(AllowEmptyStrings = true)]
        public string Id { get; set; } = default!;
        /// <summary>
        /// List of users who are part of the conversation
        /// </summary>
        [JsonPropertyName("users")]
        [Required]
        public ICollection<UserForPublic> Users { get; set; } = new Collection<UserForPublic>();
        /// <summary>
        /// The last message sent
        /// </summary>
        [JsonPropertyName("lastMessage")]
        public LastMessageForPublic? LastMessage { get; set; } = default!;
        /// <summary>
        /// Is the conversation unread
        /// </summary>
        [JsonPropertyName("unread")]
        public bool Unread { get; set; } = default!;
        /// <summary>
        /// Conversation status
        /// </summary>
        [JsonPropertyName("status")]
        [Required(AllowEmptyStrings = true)]
        [JsonConverter(typeof(CustomStringEnumConverter<ConversationForPublicStatus>))]
        public ConversationForPublicStatus Status { get; set; } = default!;
        /// <summary>
        /// Created at
        /// </summary>
        [JsonPropertyName("createdAt")]
        [Required(AllowEmptyStrings = true)]
        public DateTimeOffset CreatedAt { get; set; } = default!;
        /// <summary>
        /// Last message at
        /// </summary>
        [JsonPropertyName("lastMessageAt")]
        [Required(AllowEmptyStrings = true)]
        public DateTimeOffset LastMessageAt { get; set; } = default!;
        /// <summary>
        /// Whether the user is part of the conversation
        /// </summary>
        [JsonPropertyName("isMember")]
        public bool IsMember { get; set; } = default!;
        /// <summary>
        /// Whether the sender is banned
        /// </summary>
        [JsonPropertyName("isSenderBanned")]
        public bool IsSenderBanned { get; set; } = default!;
        /// <summary>
        /// The conversation type
        /// </summary>
        [JsonPropertyName("type")]
        [Required(AllowEmptyStrings = true)]
        [JsonConverter(typeof(CustomStringEnumConverter<ConversationForPublicType>))]
        public ConversationForPublicType Type { get; set; } = default!;

    }

}