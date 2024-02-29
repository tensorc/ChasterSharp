using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class CreatePostReportItemDto : CreateReportBase
    {
        /// <summary>
        /// The post id
        /// </summary>
        [JsonPropertyName("postId")]
        [Required(AllowEmptyStrings = true)]
        public string PostId { get; set; } = default!;

        public CreatePostReportItemDto() 
        {
            Type = ReportType.Post;
        }

    }

}