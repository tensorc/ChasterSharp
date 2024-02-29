using System.Runtime.Serialization;

namespace ChasterSharp
{
    public enum FeatureSwitch
    {
        Unknown = -1,
        [EnumMember(Value = "partner_extensions")]
        PartnerExtensions = 0,
        [EnumMember(Value = "can_join_shared_lock_status")]
        CanJoinSharedLockStatus = 1,
        [EnumMember(Value = "require_plus_for_findoms")]
        RequirePlusForFindoms = 2,
        [EnumMember(Value = "age_verification")]
        AgeVerification = 3,
        [EnumMember(Value = "block_registration_with_disposable_email")]
        BlockRegistrationWithDisposableEmail = 4,
        [EnumMember(Value = "block_registration_with_vpn")]
        BlockRegistrationWithVpn = 5,
        [EnumMember(Value = "search_engine_for_users")]
        SearchEngineForUsers = 6,
        [EnumMember(Value = "push_notifications")]
        PushNotifications = 7,
        [EnumMember(Value = "other")]
        Other = 8,
        [EnumMember(Value = "dummy_1")]
        Dummy1 = 9,
        [EnumMember(Value = "dummy_2")]
        Dummy2 = 10,
        [EnumMember(Value = "dummy_3")]
        Dummy3 = 11
    }

}