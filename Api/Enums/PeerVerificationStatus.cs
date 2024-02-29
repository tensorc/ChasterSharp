using System.Runtime.Serialization;

namespace ChasterSharp
{
    public enum PeerVerificationStatus
    {
        Unknown = -1,
        [EnumMember(Value = "ongoing")]
        Ongoing = 0,
        [EnumMember(Value = "verified")]
        Verified = 1,
        [EnumMember(Value = "rejected")]
        Rejected = 2
    }

}