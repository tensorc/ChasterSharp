using System.Collections.ObjectModel;
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
        public ICollection<UserAchievementsRepDto> Achievements { get; set; } = new Collection<UserAchievementsRepDto>();
        [JsonPropertyName("sharedLocks")]
        [Required]
        public ICollection<PublicLockForProfilePage> SharedLocks { get; set; } = new Collection<PublicLockForProfilePage>();
        [JsonPropertyName("chastikeyStats")]
        public ChastikeyStatsForPublic? ChastikeyStats { get; set; } = default!;

    }

}