using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class ExtensionPartyForPublic
    {
        /// <summary>
        /// The extension slug. 
        /// </summary>
        [JsonPropertyName("slug")]
        [Required(AllowEmptyStrings = true)]
        public string Slug { get; set; } = default!;
        /// <summary>
        /// The extension configuration. 
        /// </summary>
        [JsonPropertyName("config")]
        [Required]
        public JsonElement Config { get; set; } = default!;
        [JsonPropertyName("_id")]
        [Required(AllowEmptyStrings = true)]
        public string Id { get; set; } = default!;
        /// <summary>
        /// This is the name of the extension, which will be displayed to other users in the list of extensions, and in the description of locks.
        /// </summary>
        [JsonPropertyName("displayName")]
        [Required(AllowEmptyStrings = true)]
        public string DisplayName { get; set; } = default!;
        /// <summary>
        /// This is the description of your extension, it is a paragraph explaining how your extension works, and what its purpose is.
        /// </summary>
        [JsonPropertyName("summary")]
        [Required(AllowEmptyStrings = true)]
        public string Summary { get; set; } = default!;
        /// <summary>
        /// This is the subtitle of the extension, it is a short sentence explaining the concept of your extension, and will be displayed in the list of extensions.
        /// </summary>
        [JsonPropertyName("subtitle")]
        [Required(AllowEmptyStrings = true)]
        public string Subtitle { get; set; } = default!;
        /// <summary>
        /// The icon you choose must be one of the regular icons available on FontAwesome 5, which you can find list here. The icon will be displayed in the list of extensions.
        /// <br/>
        /// <br/>Contact us if you want to change the icon of your extension.
        /// </summary>
        [JsonPropertyName("icon")]
        [Required(AllowEmptyStrings = true)]
        public string Icon { get; set; } = default!;
        /// <summary>
        /// An extension can offer different modes, depending on the way it works and the actions to be performed. An action is a user interaction, for example in Chaster extensions, spinning the wheel of fortune, assigning a task, or checking in. The frequency of the actions can be defined and limited according to the mode chosen by the user among the modes offered by the extension.
        /// <br/>
        /// <br/>More information: https://docs.chaster.app/api/extensions-api/configuration#available-modes
        /// </summary>
        [JsonPropertyName("mode")]
        [Required(AllowEmptyStrings = true)]
        [JsonConverter(typeof(CustomStringEnumConverter<LockExtensionMode>))]
        public LockExtensionMode Mode { get; set; } = default!;
        [JsonPropertyName("userData")]
        [Required]
        public JsonElement UserData { get; set; } = default!;
        /// <summary>
        /// The regularity displayed in the configuration, if the user chooses the cumulative or non-cumulative mode. If you enable only Unlimited mode, you don't need to fill this parameter.
        /// </summary>
        [JsonPropertyName("regularity")]
        public int Regularity { get; set; } = default!;
        /// <summary>
        /// The number of regular actions remaining. If the mode is Unlimited, it returns -1.
        /// <br/>
        /// <br/>Use it to display the number of actions remaining to the user, and know when the user can perform a regular action.
        /// <br/>If the value is 0, the user cannot perform a regular action.
        /// </summary>
        [JsonPropertyName("nbActionsRemaining")]
        public int NbActionsRemaining { get; set; } = default!;
        /// <summary>
        /// The date when the next regular action can be performed.
        /// <br/>
        /// <br/>Use it to compare the current date with the next action date to know when the user can perform a regular action.
        /// <br/>If the value is null, the user can perform a regular action.
        /// <br/>If the mode is Unlimited, it always returns null.
        /// </summary>
        [JsonPropertyName("nextActionDate")]
        public string? NextActionDate { get; set; } = default!;
        [JsonPropertyName("isPartner")]
        public bool IsPartner { get; set; } = default!;
        [JsonPropertyName("textConfig")]
        [Required(AllowEmptyStrings = true)]
        public string TextConfig { get; set; } = default!;
        /// <summary>
        /// Created at
        /// </summary>
        [JsonPropertyName("createdAt")]
        [Required(AllowEmptyStrings = true)]
        public string CreatedAt { get; set; } = default!;
        /// <summary>
        /// Updated at
        /// </summary>
        [JsonPropertyName("updatedAt")]
        [Required(AllowEmptyStrings = true)]
        public string UpdatedAt { get; set; } = default!;

        public ExtensionSlug GetExtensionSlug()
        {
            return (ExtensionSlug)EnumStringConverter.GetEnumFromMemberValue(typeof(ExtensionSlug), Slug);
        }

    }

}