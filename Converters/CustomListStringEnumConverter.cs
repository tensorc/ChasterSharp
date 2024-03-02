using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class CustomListStringEnumConverter<TEnum> : JsonConverter<List<TEnum>> where TEnum : Enum
    {
        public override List<TEnum> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartArray) throw new JsonException($"Expected StartArray but got {reader.TokenType}.");

            List<TEnum> collection = [];

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndArray) return collection;

                if (reader.TokenType != JsonTokenType.String) throw new JsonException($"Expected String but got {reader.TokenType}.");

                var enumValue = (TEnum)EnumStringConverter.GetEnumFromMemberValue(typeof(TEnum), reader.GetString());

                collection.Add(enumValue);
            }

            throw new JsonException("Unexpected end when reading JSON.");
        }

        public override void Write(Utf8JsonWriter writer, List<TEnum> value, JsonSerializerOptions options)
        {
            ArgumentNullException.ThrowIfNull(writer, nameof(writer));
            ArgumentNullException.ThrowIfNull(value, nameof(value));

            writer.WriteStartArray();

            foreach (var item in value) writer.WriteStringValue(item.ToString());

            writer.WriteEndArray();
        }
    }

}