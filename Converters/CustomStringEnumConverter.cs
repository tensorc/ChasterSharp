using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChasterSharp
{

    public sealed class CustomStringEnumConverter<TEnum> : JsonConverter<TEnum> where TEnum : Enum
    {
        public override TEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.TokenType != JsonTokenType.String
                ? throw new JsonException($"Expected String but got {reader.TokenType}.")
                : (TEnum)EnumStringConverter.GetEnumFromMemberValue(typeof(TEnum), reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options)
        {
            ArgumentNullException.ThrowIfNull(writer, nameof(writer));

            writer.WriteStringValue(EnumStringConverter.GetMemberValueFromEnum(value));
        }
    }

}