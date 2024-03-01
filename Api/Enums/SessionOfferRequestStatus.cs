using System.Runtime.Serialization;

namespace ChasterSharp
{
    public enum SessionOfferRequestStatus
    {
        Unknown = -1,
        [EnumMember(Value = "pending")]
        Pending = 0,
        [EnumMember(Value = "accepted")]
        Accepted = 1,
        [EnumMember(Value = "rejected")]
        Rejected = 2
    }

}