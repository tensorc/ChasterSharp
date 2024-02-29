using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class AssignVoteTaskActionModel
    {
        [JsonPropertyName("requestVote")]
        public bool RequestVote { get; set; } 

        [JsonPropertyName("voteDuration")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? VoteDuration { get; set; } 
    }

}

