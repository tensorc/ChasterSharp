Purpose
--------
ChasterSharp is a lightweight C# wrapper for Chaster.app API, designed to provide a foundational framework for building more advanced clients and applications on top of it. The intended use case of this framework is to support bots and other service integrations to interact with Chaster directly, as opposed to extending Chaster's functionality via the Extensions API. As such, support for partner extensions will be limited if available at all.

Getting Started
--------

All service calls are handled through the ChasterClient type, simply initiate one with a HttpClient instance and an API auth token.

<!-- snippet: instance -->
```cs
HttpClient httpClient = new();
ChasterClient chasterClient = new(httpClient, CHASTER_AUTH_TOKEN);
```
<!-- endSnippet -->

You can then perform actions on the current user's lock(s), such as adding time.

<!-- snippet: add-time -->
```cs
var personalLocks = await chasterClient.GetLocksAsync(UserLockStatus.Active);

if (personalLocks is null)
    return;

foreach (var personalLock in personalLocks)
{
    await chasterClient.AddLockTimeAsync(personalLock.Id, 60 * 60 * 24); //Add 24h to lock
}
```
<!-- endSnippet -->

The API coverage is pretty good, including undocumented functionality such as sending wearers to the pillory.

<!-- snippet: pillory-wearer -->
```cs
var searchDto = new KeyholderSearchLocksDto()
{
    Status = KeyholderSearchLocksDtoStatus.Locked,
};

//There is potential pagination here, but you get the idea
var wearerLocks = await chasterClient.SearchLockedUsersAsync(searchDto);

if (wearerLocks is null)
    return;

foreach (var wearerLock in wearerLocks.Locks)
{
    string? pilloryExtensionId = wearerLock.Extensions.
        FirstOrDefault(x => x.GetExtensionSlug() == ExtensionSlug.Pillory)?.Id;

    if (string.IsNullOrEmpty(pilloryExtensionId))
        continue; //Pillory extension not found

    if (wearerLock.IsFrozen)
        await chasterClient.PilloryLockAsync(wearerLock.Id, pilloryExtensionId, "for being frozen", 60 * 10);
}
```
<!-- endSnippet -->

In some cases you will encounter properties with a type of JsonElement as opposed to a strongly typed class. This is because the object for these properties are dynamic and have different structures (e.g., Config, Payload, and UserData). The intended handling in these cases is to determine the object type either from a sibling property, or by a property within the JsonElement itself. You can then deserialize to a common type via JsonElement.Deserialize<T>(obj) and, inversely, serialize to a JsonElement using JsonSerializer.SerializeToElement(obj).

<!-- snippet: update-extensions -->
```cs
public static async Task UpdateDiceExtension(ChasterClient client, LockForKeyholder keyholderLock, int diceMultiplier)
{
    if (!keyholderLock.Trusted)
        return; //Not trusted, so we can't modify extensions

    var lockExtensions = keyholderLock.Extensions.ToList();
    var diceExtensionIndex = lockExtensions.FindIndex(x => x.GetExtensionSlug() == ExtensionSlug.Dice);

    if (diceExtensionIndex == -1)
        return; //Dice extension not found

    var diceExtensionConfig = lockExtensions[diceExtensionIndex].Config.Deserialize<DiceConfig>()!;
    diceExtensionConfig.Multiplier = diceMultiplier;

    lockExtensions[diceExtensionIndex].Config = JsonSerializer.SerializeToElement(diceExtensionConfig);
    keyholderLock.Extensions = lockExtensions; //Ensure we keep track of the extension state

    var editExtensionsDto = new EditLockExtensionsDto()
    {
        Extensions = ToLockExtensionConfig(keyholderLock.Extensions)
    };

    await client.UpdateLockExtensionsAsync(keyholderLock.Id, editExtensionsDto);
}

public static ICollection<LockExtensionConfigDto> ToLockExtensionConfig(ICollection<ExtensionPartyForPublic> extensions)
{
    var configs = new List<LockExtensionConfigDto>();

    foreach (var extension in extensions)
    {
        configs.Add(new LockExtensionConfigDto()
        {
            Slug = extension.Slug,
            Config = extension.Config,
            Mode = extension.Mode,
            Regularity = extension.Regularity
        });
    }

    return configs;
}
```
<!-- endSnippet -->

Considerations
--------
It's important to keep in mind that this project is intended as a foundation for more sophisticated clients. Transient HTTP errors are inevitable and you should take steps to retry failed API calls, a package such as Polly may be a good solution here. 

Furthermore, it is quite burdensome to perform more complex tasks such as updating extensions on a lock. For these reasons, it is important for you to build functionality on top of this base rather than relying on it soley.

Contributing
--------
Contributions are encouraged! Whether it's refining existing features, adding new functionalities, or enhancing documentation, your contributions can help enrich the framework for the entire community. Consider joining our Discord server if you are interested in helping.

https://discord.gg/X4akpQE6aU
