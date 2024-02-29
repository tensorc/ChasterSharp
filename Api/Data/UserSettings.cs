using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class UserSettings
    {
        [JsonPropertyName("showLocksOnProfile")]
        public bool ShowLocksOnProfile { get; set; } = default!;
        [JsonPropertyName("showOnlineStatus")]
        public bool ShowOnlineStatus { get; set; } = default!;
        [JsonPropertyName("showDiscordOnProfile")]
        public bool ShowDiscordOnProfile { get; set; } = default!;
        [JsonPropertyName("emailOnWearerUsesSharedLock")]
        public bool EmailOnWearerUsesSharedLock { get; set; } = default!;
        [JsonPropertyName("messageOnWearerUsesSharedLock")]
        public bool MessageOnWearerUsesSharedLock { get; set; } = default!;
        [JsonPropertyName("discordNotifications")]
        public bool DiscordNotifications { get; set; } = default!;
        [JsonPropertyName("discordMessagingNotifications")]
        public bool DiscordMessagingNotifications { get; set; } = default!;
        [JsonPropertyName("displayNsfw")]
        public bool DisplayNsfw { get; set; } = default!;
        [JsonPropertyName("showAge")]
        public bool ShowAge { get; set; } = default!;

    }

}