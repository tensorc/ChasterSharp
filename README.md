Purpose
--------
ChasterSharp is a lightweight C# wrapper for Chaster.app API, designed to provide a foundational framework for building more advanced clients and applications on top of it. The intended use case of this framework is to support bots and other service integrations to interact with Chaster directly, as opposed to extending Chaster's functionality via the Extensions API. As such, support for partner extensions will be limited if available at all.

Getting Started
--------

All service calls are handled through the ChasterClient type, simply initiate one with an HttpClient instead and an API auth token.

<!-- snippet: add-time -->
```cs
HttpClient httpClient = new();
ChasterClient chasterClient = new(httpClient, CHASTER_AUTH_TOKEN);

var personalLocks = await chasterClient.GetLocksAsync(UserLockStatus.Active);

if (personalLocks is null)
    return;

foreach (var personalLock in personalLocks)
{
    await chasterClient.AddLockTimeAsync(personalLock.Id, 60 * 60 * 24); //NOTE: Add 24h to lock
}
```
<!-- endSnippet -->

The API coverage is pretty good, including undocumented functionality such as sending wearers to the pillory.

<!-- snippet: pillory-wearer -->
```cs
HttpClient httpClient = new();
ChasterClient chasterClient = new(httpClient, CHASTER_AUTH_TOKEN);

var searchDto = new KeyholderSearchLocksDto()
{
    Status = KeyholderSearchLocksDtoStatus.Locked,
};

//NOTE: There is potential pagination here, but you get the idea
var wearerLocks = await chasterClient.SearchLockedUsersAsync(searchDto);

if (wearerLocks is null)
    return;

foreach (var wearerLock in wearerLocks.Locks)
{
    string? pilloryExtensionId = wearerLock.Extensions.
        FirstOrDefault(x => x.GetExtensionSlug() == ExtensionSlug.Pillory)?.Id;

    if (string.IsNullOrEmpty(pilloryExtensionId))
        continue; //NOTE: Pillory extension not enabled for wearer

    if (wearerLock.IsFrozen)
        await chasterClient.PilloryLockAsync(wearerLock.Id, pilloryExtensionId, "for being frozen", 60 * 10);
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
