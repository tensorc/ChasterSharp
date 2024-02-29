using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class CreateMessageReportItemDto : CreateReportBase
    {
        /// <summary>
        /// The message id
        /// </summary>
        [JsonPropertyName("messageId")]
        [Required(AllowEmptyStrings = true)]
        public string MessageId { get; set; } = default!;

        public CreateMessageReportItemDto()
        {
            Type = ReportType.Message;
        }
    }

}