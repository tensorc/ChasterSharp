using System.Text.Json;

namespace ChasterSharp;

internal static class Util
{

    public static readonly JsonElement EmptyJsonElement = JsonSerializer.Deserialize<JsonElement>("{}");

}