using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class ExtensionOwnerForPublic
    {
        [JsonPropertyName("username")]
        [Required(AllowEmptyStrings = true)]
        public string Username { get; set; } = default!;

    }

}