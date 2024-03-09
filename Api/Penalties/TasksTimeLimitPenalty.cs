

using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class TasksTimeLimitPenalty : PenaltyBase
    {
        [JsonPropertyName("params")]
        public PenaltyTimeLimitParams? Params { get; set; } = new();

        public TasksTimeLimitPenalty()
        {
            Name = PenaltyName.TasksTimeLimit;
        }
    }

}