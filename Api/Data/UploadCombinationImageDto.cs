using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class UploadCombinationImageDto
    {
        /// <summary>
        /// The combination image
        /// </summary>
        [JsonPropertyName("file")]
        [Required(AllowEmptyStrings = true)]
        public FileParameter File { get; set; } = default!;
        /// <summary>
        /// Enables the manual combination image check, for Premium users.
        /// </summary>
        [JsonPropertyName("enableManualCheck")]
        public bool? EnableManualCheck { get; set; } = default!;

    }

}