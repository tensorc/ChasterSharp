using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class UpdateTasksActionModel
    {
        [JsonPropertyName("tasks")]
        public ICollection<TaskActionParamsModel> Tasks { get; set; } = new Collection<TaskActionParamsModel>();
    }

}