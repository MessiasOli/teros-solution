using System.Net.Http.Json;
using TEROS.Domain.Model.OpenBanking;

public class OpenBankingHttpClient
{
    private readonly HttpClient _httpClient;

    public OpenBankingHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public async Task<List<Organization>> GetOrganizationsAsync(string apiUrl)
    {
        try
        {
            var response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var organizations = await response.Content.ReadFromJsonAsync<List<Organization>>();
                return organizations;
            }
            else
            {
                Console.WriteLine($"Erro na solicitação: {response.StatusCode}");
                return null;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao fazer a solicitação HTTP: {ex.Message}");
            return null;
        }
    }
}
