﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class CommunityEventCategory
    {
        [JsonPropertyName("name")]
        [Required(AllowEmptyStrings = true)]
        public string Name { get; set; } = default!;
        [JsonPropertyName("title")]
        [Required(AllowEmptyStrings = true)]
        public string Title { get; set; } = default!;
        [JsonPropertyName("maxPoints")]
        public int? MaxPoints { get; set; } = default!;
        [JsonPropertyName("actions")]
        [Required]
        public List<CommunityEventAction> Actions { get; set; } = [];
        [JsonPropertyName("hidden")]
        public bool? Hidden { get; set; } = default!;

    }

}