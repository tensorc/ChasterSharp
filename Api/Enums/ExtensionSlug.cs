using System.Runtime.Serialization;

namespace ChasterSharp
{
    public enum ExtensionSlug
    {
        Unknown = -1,
        [EnumMember(Value = "dice")]
        Dice,
        [EnumMember(Value = "guess-timer")]
        GuessTheTimer,
        [EnumMember(Value = "temporary-opening")]
        HygieneOpening,
        [EnumMember(Value = "link")]
        ShareLink,
        [EnumMember(Value = "penalty")]
        Penalties,
        [EnumMember(Value = "pillory")]
        Pillory,
        [EnumMember(Value = "random-events")]
        RandomEvents,
        [EnumMember(Value = "tasks")]
        Tasks,
        [EnumMember(Value = "verification-picture")]
        VerificationPicture,
        [EnumMember(Value = "wheel-of-fortune")]
        WheelOfFortune
    }

}