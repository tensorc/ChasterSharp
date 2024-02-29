using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class DiceConfig
    {
        [JsonPropertyName("multiplier")]
        public int Multiplier { get; set; }
    }

}