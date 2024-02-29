using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class CreateReportDto
    {
        /// <summary>
        /// The content to report
        /// </summary>
        [JsonPropertyName("target")]
        [Required]
        public JsonElement Target { get; set; } = default!;
        /// <summary>
        /// The reason of the report
        /// </summary>
        [JsonPropertyName("reason")]
        [Required(AllowEmptyStrings = true)]
        [JsonConverter(typeof(CustomStringEnumConverter<CreateReportDtoReason>))]
        public CreateReportDtoReason Reason { get; set; } = default!;
        /// <summary>
        /// An optional message
        /// </summary>
        [JsonPropertyName("message")]
        public string? Message { get; set; } = default!;

        //TODO: Add function to get ReportType from Target?

    }

}