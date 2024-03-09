using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class LogDiceRolledPayload
    {
        [JsonPropertyName("adminDice")]
        public int AdminDice { get; set; }

        [JsonPropertyName("playerDice")]
        public int PlayerDice { get; set; }

        [JsonPropertyName("duration")]
        public int Duration { get; set; }
    }

}