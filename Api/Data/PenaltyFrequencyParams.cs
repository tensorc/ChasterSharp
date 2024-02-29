using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class PenaltyFrequencyParams
    {
        [JsonPropertyName("nbActions")]
        public int Actions { get; set; }

        [JsonPropertyName("frequency")]
        public int Frequency { get; set; }

    }

}