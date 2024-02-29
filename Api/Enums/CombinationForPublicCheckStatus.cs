using System.Runtime.Serialization;

namespace ChasterSharp
{
    public enum CombinationForPublicCheckStatus
    {
        Unknown = -1,
        [EnumMember(Value = "pending")]
        Pending = 0,
        [EnumMember(Value = "verified")]
        Verified = 1,
        [EnumMember(Value = "failed")]
        Failed = 2
    }

}