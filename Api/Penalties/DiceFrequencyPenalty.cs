

using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class DiceFrequencyPenalty : PenaltyBase
    {
        [JsonPropertyName("params")]
        public PenaltyFrequencyParams? Params { get; set; } = new();

        public DiceFrequencyPenalty()
        {
            Name = PenaltyName.DiceRoll;
        }
    }

}