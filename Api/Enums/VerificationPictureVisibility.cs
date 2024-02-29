using System.Runtime.Serialization;

namespace ChasterSharp
{
    public enum VerificationPictureVisibility
    {
        Unknown = -1,
        [EnumMember(Value = "all")]
        All = 0,
        [EnumMember(Value = "keyholder")]
        Keyholder = 1
    }

}