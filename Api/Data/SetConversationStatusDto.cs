using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class SetConversationStatusDto
    {
        /// <summary>
        /// The new conversation status
        /// </summary>
        [JsonPropertyName("status")]
        [Required(AllowEmptyStrings = true)]
        [JsonConverter(typeof(CustomStringEnumConverter<SetConversationStatusDtoStatus>))]
        public SetConversationStatusDtoStatus Status { get; set; } 

    }

}