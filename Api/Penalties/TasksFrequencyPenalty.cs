

using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class TasksFrequencyPenalty : PenaltyBase
    {
        [JsonPropertyName("params")]
        public PenaltyFrequencyParams? Params { get; set; } = new();

        public TasksFrequencyPenalty()
        {
            Name = PenaltyName.Tasks;
        }
    }

}