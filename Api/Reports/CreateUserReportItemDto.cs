using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class CreateUserReportItemDto : CreateReportBase
    {
        /// <summary>
        /// The user id
        /// </summary>
        [JsonPropertyName("userId")]
        [Required(AllowEmptyStrings = true)]
        public string UserId { get; set; } = default!;

        public CreateUserReportItemDto()
        {
            Type = ReportType.User;
        }
    }

}