using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public abstract class CreateReportBase 
    {
        /// <summary>
        /// The report type
        /// <br/>Equals to `message`
        /// </summary>
        [JsonPropertyName("type")]
        [Required(AllowEmptyStrings = true)]
        [JsonConverter(typeof(CustomStringEnumConverter<ReportType>))]
        public ReportType Type { get; set; } 

    }

}