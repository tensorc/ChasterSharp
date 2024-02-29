

using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class PenaltyUserDataParams
    {
        [JsonPropertyName("periodStart")]
        public DateTimeOffset PeriodStart { get; set; }

        [JsonPropertyName("periodEnd")]
        public DateTimeOffset PeriodEnd { get; set; }

        [JsonPropertyName("nbActionsCompleted")]
        public int ActionsCompleted { get; set; }

        [JsonPropertyName("nbActionsRequired")]
        public int ActionsRequired { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("prefix")]
        public string? Prefix { get; set; }

        public PenaltyName GetPenaltyName()
        {
            return (PenaltyName)EnumStringConverter.GetEnumFromMemberValue(typeof(PenaltyName), Name);
        }
    }
}
