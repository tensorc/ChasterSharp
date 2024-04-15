using System.Runtime.Serialization;
using System.Text.Json;

namespace ChasterSharp
{
    public sealed class EnumStringConverter
    {

        public static Enum GetEnumFromMemberValue(Type typeToConvert, string? enumMemberValue)
        {
            ArgumentNullException.ThrowIfNull(typeToConvert);

            foreach (var field in typeToConvert.GetFields())
                if (Attribute.GetCustomAttribute(field, typeof(EnumMemberAttribute)) is EnumMemberAttribute enumMemberAttribute && enumMemberAttribute.Value == enumMemberValue)
                {
                    var value = field.GetValue(null);

                    if (value is null)
                        break;

                    return (Enum)value;
                }

            return (Enum)Enum.ToObject(typeToConvert, -1);
        }

        public static string? GetMemberValueFromEnum(Enum value)
        {
            ArgumentNullException.ThrowIfNull(value);

            var enumString = value.ToString();

            foreach (var field in value.GetType().GetFields())
                if (Attribute.GetCustomAttribute(field, typeof(EnumMemberAttribute)) is EnumMemberAttribute enumMemberAttribute && field.Name == enumString) return enumMemberAttribute.Value;

            throw new JsonException($"Unknown {value.GetType().Name} value: {enumString}");
        }

    }
}