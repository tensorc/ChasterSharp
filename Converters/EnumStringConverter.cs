using System.Runtime.Serialization;
using System.Text.Json;

namespace ChasterSharp
{
    public sealed class EnumStringConverter
    {

        public static Enum GetEnumFromMemberValue(Type typeToConvert, string? enumMemberValue)
        {
            foreach (var field in typeToConvert.GetFields())
                if (Attribute.GetCustomAttribute(field, typeof(EnumMemberAttribute)) is EnumMemberAttribute enumMemberAttribute && enumMemberAttribute.Value == enumMemberValue)
                {
                    var value = field.GetValue(null);

                    return value != null ? (Enum)value : throw new JsonException($"Value retrieved from field is null for {typeToConvert.Name}.");
                }

            return (Enum)Enum.ToObject(typeToConvert, -1);
        }

        public static string? GetMemberValueFromEnum(Enum value)
        {
            var enumString = value.ToString();

            foreach (var field in value.GetType().GetFields())
                if (Attribute.GetCustomAttribute(field, typeof(EnumMemberAttribute)) is EnumMemberAttribute enumMemberAttribute && field.Name == enumString) return enumMemberAttribute.Value;

            throw new JsonException($"Unknown {value.GetType().Name} value: {enumString}");
        }

    }
}