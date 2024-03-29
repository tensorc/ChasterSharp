﻿using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class LogPilloryStartedPayload
    {
        [JsonPropertyName("duration")]
        public int Duration { get; set; }

        [JsonPropertyName("reason")]
        public string? Reason { get; set; }
    }

}