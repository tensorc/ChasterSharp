using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class CreateSharedLockReportItemDto : CreateReportBase
    {
        /// <summary>
        /// The shared lock id
        /// </summary>
        [JsonPropertyName("sharedLockId")]
        [Required(AllowEmptyStrings = true)]
        public string SharedLockId { get; set; } = default!;

        public CreateSharedLockReportItemDto() 
        {
            Type = ReportType.SharedLock;
        }

    }

}