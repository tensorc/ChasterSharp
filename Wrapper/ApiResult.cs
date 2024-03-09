using System.Net;
using System.Text.Json;

namespace ChasterSharp
{
    public record ApiResult<T>(T? Value, HttpResponseMessage? HttpResponse, HttpStatusCode? StatusCode)
    {
    }

    public record ApiResult(HttpResponseMessage? HttpResponse, HttpStatusCode? StatusCode)
    {

        public async Task<T?> GetObjectAsync<T>()
        {
            if (HttpResponse is null)
                return default;

            var stream = await HttpResponse.Content.ReadAsStreamAsync().ConfigureAwait(false);
            return await JsonSerializer.DeserializeAsync<T>(stream).ConfigureAwait(false);
        }

        public async Task<byte[]?> GetBytesAsync()
        {
            if (HttpResponse is null)
                return null;

            return await HttpResponse.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
        }

    }
}