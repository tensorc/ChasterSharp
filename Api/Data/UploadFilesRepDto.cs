using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class UploadFilesRepDto
    {
        /// <summary>
        /// The attachment token
        /// <br/>
        /// <br/>It can be used in messaging, post and other endpoints that support
        /// <br/>attachments
        /// </summary>
        [JsonPropertyName("token")]
        [Required(AllowEmptyStrings = true)]
        public string Token { get; set; } = default!;

    }

}