using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class SetConversationUnreadDto
    {
        /// <summary>
        /// True if unread
        /// </summary>
        [JsonPropertyName("unread")]
        public bool Unread { get; set; } 

    }

}