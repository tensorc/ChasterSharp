﻿using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class ExtensionCriteriaData
    {
        [JsonPropertyName("extensions")]
        [Required]
        public ICollection<string> Extensions { get; set; } = new Collection<string>();
        [JsonPropertyName("all")]
        public bool All { get; set; } = false;

    }

}