using System.Runtime.Serialization;

namespace ChasterSharp
{
    public enum CreateReportDtoReason
    {
        Unknown = -1,
        [EnumMember(Value = "harassment")]
        Harassment = 0,
        [EnumMember(Value = "suicide_self_injury")]
        SuicideSelfInjury = 1,
        [EnumMember(Value = "inappropriate_content")]
        InappropriateContent = 2,
        [EnumMember(Value = "hate_speech")]
        HateSpeech = 3,
        [EnumMember(Value = "unsolicited_content")]
        UnsolicitedContent = 4,
        [EnumMember(Value = "unauthorized_financial_activity")]
        UnauthorizedFinancialActivity = 5,
        [EnumMember(Value = "other")]
        Other = 6
    }

}