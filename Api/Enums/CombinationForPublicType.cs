using System.Runtime.Serialization;

namespace ChasterSharp
{
    public enum CombinationForPublicType
    {
        Unknown = -1,
        [EnumMember(Value = "image")]
        Image = 0,
        [EnumMember(Value = "code")]
        Code = 1
    }

}