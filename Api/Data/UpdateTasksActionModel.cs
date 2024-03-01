
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class UpdateTasksActionModel
    {
        [JsonPropertyName("tasks")]
        public List<TaskActionParamsModel> Tasks { get; set; } = [];
    }

}