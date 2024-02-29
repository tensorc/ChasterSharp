using System.Collections.ObjectModel;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChasterSharp
{
    public sealed class CustomICollectionStringEnumConverter<TEnum> : JsonConverter<ICollection<TEnum>> where TEnum : Enum
    {
        public override ICollection<TEnum> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartArray) throw new JsonException($"Expected StartArray but got {reader.TokenType}.");

            Collection<TEnum> collection = new();

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndArray) return collection;

                if (reader.TokenType != JsonTokenType.String) throw new JsonException($"Expected String but got {reader.TokenType}.");

                var enumValue = (TEnum)EnumStringConverter.GetEnumFromMemberValue(typeof(TEnum), reader.GetString());

                collection.Add(enumValue);
            }

            throw new JsonException("Unexpected end when reading JSON.");
        }

        public override void Write(Utf8JsonWriter writer, ICollection<TEnum> value, JsonSerializerOptions options)
        {
            ArgumentNullException.ThrowIfNull(writer, nameof(writer));

            writer.WriteStartArray();

            foreach (var item in value) writer.WriteStringValue(item.ToString());

            writer.WriteEndArray();
        }
    }


    //public sealed class CustomICollectionStringEnumConverter : JsonConverter<ICollection<Enum>>
    //{
    //    public override ICollection<Enum>? Read(ref Utf8JsonReader reader, System.Type typeToConvert, JsonSerializerOptions options)
    //    {
    //        System.Type enumType = typeToConvert.GetGenericArguments()[0]; // Get the underlying enum type

    //        if (!enumType.IsEnum)
    //        {
    //            throw new JsonException("The type is not an enum type.");
    //        }

    //        if (reader.TokenType != JsonTokenType.StartArray)
    //        {
    //            throw new JsonException($"Expected StartArray but got {reader.TokenType}.");
    //        }

    //        var collection = new Collection<Enum>();

    //        while (reader.Read())
    //        {
    //            if (reader.TokenType == JsonTokenType.EndArray)
    //            {
    //                return collection;
    //            }

    //            if (reader.TokenType != JsonTokenType.String)
    //            {
    //                throw new JsonException($"Expected String but got {reader.TokenType}.");
    //            }

    //            Enum enumValue = JsonEnumConverter.GetEnumFromMemberValue(enumType, reader.GetString());

    //            if (enumValue is not null)
    //            {
    //                collection.Add(enumValue);
    //            }
    //        }

    //        throw new JsonException("Unexpected end when reading JSON.");
    //    }

    //    public override void Write(Utf8JsonWriter writer, ICollection<Enum> value, JsonSerializerOptions options)
    //    {
    //        writer.WriteStartArray();

    //        foreach (var item in value)
    //        {
    //            writer.WriteStringValue(item.ToString());
    //        }

    //        writer.WriteEndArray();
    //    }
    //}

}