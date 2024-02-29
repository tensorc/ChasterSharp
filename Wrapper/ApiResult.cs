using System.Text.Json;

namespace ChasterSharp
{
    public record ApiResult(HttpResponseMessage HttpResponse)
    {
        public async Task<T?> GetObjectAsync<T>()
        {
            var stream = await HttpResponse.Content.ReadAsStreamAsync().ConfigureAwait(false);
            return await JsonSerializer.DeserializeAsync<T>(stream).ConfigureAwait(false);
        }

        public async Task<byte[]> GetBytesAsync()
        {
            return await HttpResponse.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
        }

    }
}