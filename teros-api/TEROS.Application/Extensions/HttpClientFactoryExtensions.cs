using TEROS.Domain.Utils;
using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Net.Http;

namespace TEROS.Application;

public static class HttpClientFactoryExtensions
{
    //Renomear este metodo algum dia para AcessarApiPost
    public static async Task<TResponse> AcessarApi<TRequest, TResponse>(this IHttpClientFactory httpClientFactory, TRequest data, string clientName, CancellationToken cancellationToken)
    {
        var client = httpClientFactory.CreateClient(clientName);
        var response = await client.PostAsJsonAsync(string.Empty, data, cancellationToken);
        var jsonString = await response.Content.ReadAsStringAsync(cancellationToken);
        var resultJSON = JsonSerializer.Deserialize<TResponse>(jsonString);
        return resultJSON;

    }
    public static async Task<TResponse> AcessarApiPostHeaders<TRequest, TResponse>(this IHttpClientFactory httpClientFactory, TRequest data, string clientName, CancellationToken cancellationToken, string authToken = null, List<Tuple<string, string>> headers = null, ILogger _logger = null)
    {
        var client = httpClientFactory.CreateClient(clientName);
        AdicionarHeaders(headers, client);
        AdicionarBearerHeaders(authToken, client);
        var requestJson = data.SerializeJsonObject();
        _logger?.LogInformation("Request enviado: {requestJson}", requestJson);
        var response = await client.PostAsJsonAsync(string.Empty, data, cancellationToken);
        var jsonString = await response.Content.ReadAsStringAsync(cancellationToken);
        var resultJSON = JsonSerializer.Deserialize<TResponse>(jsonString);
        return resultJSON;

    }

    public static async Task<TResponse> AcessarApiGet<TResponse>(this IHttpClientFactory httpClientFactory, string clientName, CancellationToken cancellationToken, string authToken = null, List<Tuple<string, string>> headers = null)
    {
        var client = httpClientFactory.CreateClient(clientName);
        AdicionarHeaders(headers, client);
        AdicionarBearerHeaders(authToken, client);
        var response = await client.GetAsync(string.Empty, cancellationToken);
        var jsonString = await response.Content.ReadAsStringAsync(cancellationToken);
        var resultJSON = JsonSerializer.Deserialize<TResponse>(jsonString);
        return resultJSON;

    }

    private static void AdicionarHeaders(List<Tuple<string, string>> headers, HttpClient client)
    {
        if (headers?.Any() ?? false)
        {
            foreach (var header in headers)
            {
                client.DefaultRequestHeaders.Add(header.Item1, header.Item2);
            }
        }
    }

    private static void AdicionarBearerHeaders(string token, HttpClient client)
    {
        if (!string.IsNullOrEmpty(token))
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }
}
