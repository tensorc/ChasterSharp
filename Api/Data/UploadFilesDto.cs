using System.Collections.ObjectModel;
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
        public ICollection<FileParameter> Files { get; set; } = new Collection<FileParameter>();

        /// <summary>
        /// The target storage
        /// </summary>
        [JsonPropertyName("type")]
        [Required(AllowEmptyStrings = true)]
        [JsonConverter(typeof(CustomStringEnumConverter<FileType>))]
        public FileType Type { get; set; } = default!;

    }

}