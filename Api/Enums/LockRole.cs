using System.Runtime.Serialization;

namespace ChasterSharp
{
    public enum LockRole
    {
        Unknown = -1,
        [EnumMember(Value = "keyholder")]
        Keyholder = 0,
        [EnumMember(Value = "wearer")]
        Wearer = 1,
        [EnumMember(Value = "visitor")]
        Visitor = 2
    }

}