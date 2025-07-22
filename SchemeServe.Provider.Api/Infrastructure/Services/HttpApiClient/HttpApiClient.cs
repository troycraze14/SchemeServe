using System.Text.Json;
using SchemeServe.Provider.Api.Domain.Models;
using SchemeServe.Provider.Api.Infrastructure.Services.Cqc.Models;

namespace SchemeServe.Provider.Api.Infrastructure.Services.HttpApiClient;

public class HttpApiClient(IHttpClientFactory httpClientFactory)
{
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
   
    private async Task<Result<T>> GetResult<T>(string path, HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
        {
            return Result<T>.Failure(HttpApiClientErrors.HttpErrorStatus(path, response.StatusCode, response.ReasonPhrase));
        }
        try
        {
            var contentStream = await response.Content.ReadAsStreamAsync();

            var content = await JsonSerializer.DeserializeAsync<T>(contentStream, JsonSerializerOptions.Web);

            return Result<T>.Success(content);
        }
        catch (Exception e)
        {
            return Result<T>.Failure(HttpApiClientErrors.UnhandledApiResponse(path, e.Message));
        }
    }

    public async Task<Result<T>> GetAsync<T>(string clientName, string path, object? queryParams = null)
    {
        if (queryParams is not null)
        {
            path = $"{path}?{queryParams.ToQueryString()}";
        }

        using var httpClient = _httpClientFactory.CreateClient(clientName);

        var response = await httpClient.GetAsync(path);

        var result = await GetResult<T>(path, response);

        return result;
    }
}