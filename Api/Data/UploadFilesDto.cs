using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class UploadFilesDto
    {
        /// <summary>
        /// The files to upload
        /// </summary>
        [JsonPropertyName("files")]
        [Required]
        public List<FileParameter> Files { get; set; } = [];

        /// <summary>
        /// The target storage
        /// </summary>
        [JsonPropertyName("type")]
        [Required(AllowEmptyStrings = true)]
        [JsonConverter(typeof(CustomStringEnumConverter<FileType>))]
        public FileType Type { get; set; } = default!;

    }

}