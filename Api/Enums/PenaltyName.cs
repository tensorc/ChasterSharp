using System.Runtime.Serialization;

namespace ChasterSharp
{
    public enum PenaltyName
    {
        Unknown = -1,
        [EnumMember(Value = "dice_roll")]
        DiceFrequency,
        [EnumMember(Value = "temporary_opening_open")]
        HygieneOpeningFrequency,
        [EnumMember(Value = "temporary_opening_time_limit")]
        HygieneOpeningTimeLimit,
        [EnumMember(Value = "tasks")]
        TasksFrequency,
        [EnumMember(Value = "tasks_do_task")]
        TasksTimeLimit,
        [EnumMember(Value = "verification_picture_verify")]
        VerificationPictureFrequency,
        [EnumMember(Value = "wheel_of_fortune_turns")]
        WheelOfFortuneFrequency
    }

}