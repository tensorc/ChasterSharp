using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class UserBadgeCount
    {
        /// <summary>
        /// Number of message requests
        /// </summary>
        [JsonPropertyName("pendingMessages")]
        public int PendingMessages { get; set; } = default!;
        /// <summary>
        /// Number of messages
        /// </summary>
        [JsonPropertyName("unreadMessages")]
        public int UnreadMessages { get; set; } = default!;
        /// <summary>
        /// Number of keyholding requests
        /// </summary>
        [JsonPropertyName("keyholdingRequests")]
        public int KeyholdingRequests { get; set; } = default!;

    }

}