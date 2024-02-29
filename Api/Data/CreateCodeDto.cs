using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class CreateCodeDto
    {
        /// <summary>
        /// The code combination
        /// </summary>
        [JsonPropertyName("code")]
        [Required(AllowEmptyStrings = true)]
        [StringLength(255)]
        public string Code { get; set; } = default!;

    }

}