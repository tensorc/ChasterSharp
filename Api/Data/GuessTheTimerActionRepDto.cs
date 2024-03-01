using System.Text.Json.Serialization;

namespace ChasterSharp;

public sealed class GuessTheTimerActionRepDto
{
    [JsonPropertyName("canBeUnlocked")]
    public bool CanBeUnlocked { get; set; } = default!;
}