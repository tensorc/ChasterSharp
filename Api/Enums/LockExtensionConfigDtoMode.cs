using System.Runtime.Serialization;

namespace ChasterSharp
{
    public enum LockExtensionConfigDtoMode
    {
        Unknown = -1,
        [EnumMember(Value = "cumulative")]
        Cumulative = 0,
        [EnumMember(Value = "non_cumulative")]
        NonCumulative = 1,
        [EnumMember(Value = "turn")]
        Turn = 2,
        [EnumMember(Value = "unlimited")]
        Unlimited = 3
    }

}