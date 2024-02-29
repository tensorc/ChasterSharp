using System.Runtime.Serialization;

namespace ChasterSharp
{
    public enum FileType
    {
        Unknown = -1,
        [EnumMember(Value = "messaging")]
        Messaging = 0,
        [EnumMember(Value = "community_event_challenge")]
        CommunityEventChallenge = 1
    }

}