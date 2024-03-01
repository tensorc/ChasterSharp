using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class ProfileRepDto
    {
        [JsonPropertyName("user")]
        [Required]
        public UserForPublic User { get; set; } = new();
        [JsonPropertyName("stats")]
        public UserStatsForPublic? Stats { get; set; } = default!;
        [JsonPropertyName("achievements")]
        [Required]
        public List<UserAchievementsRepDto> Achievements { get; set; } = [];
        [JsonPropertyName("sharedLocks")]
        [Required]
        public List<PublicLockForProfilePage> SharedLocks { get; set; } = [];
        [JsonPropertyName("chastikeyStats")]
        public ChastikeyStatsForPublic? ChastikeyStats { get; set; } = default!;

    }

}