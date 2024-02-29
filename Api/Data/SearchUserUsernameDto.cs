using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class SearchUserUsernameDto
    {
        [JsonPropertyName("search")]
        [Required(AllowEmptyStrings = true)]
        public string Search { get; set; } = default!;

    }

}