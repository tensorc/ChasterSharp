using System.Runtime.Serialization;

namespace ChasterSharp;

public enum ShareLinkVoteAction
{
    Unknown = -1,
    [EnumMember(Value = "add")]
    Add = 0,
    [EnumMember(Value = "remove")]
    Remove = 1,
    [EnumMember(Value = "random")]
    Random = 2
}