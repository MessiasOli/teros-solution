using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;
using TEROS.Domain.Services;
using TEROS.Domain.Utils;

namespace TEROS.Application.Worker
{
    public class OpenBankingObserver : BackgroundService
    {
        public string UrlOpenBanking { get; init; }
        public string UrlApiTeros { get; init; }
        public DateTime LastSystemUpdate { get; set; }
        public DateTime LastFrontUpdate { get; set; }

        private IOpenBankingService _openBankinService;

        public OpenBankingObserver(IConfiguration configuration, IOpenBankingService openBankinService)
        {
            UrlOpenBanking = configuration["urlOpenBankingBrasil"];
            UrlApiTeros = configuration["urlApiTeros"];
            _openBankinService = openBankinService;
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            string step = "";
            Debug.WriteLine("Iniciando a tarefa de monitoramento...");

            try
            {
                await LoadConfiguration();

                while (!stoppingToken.IsCancellationRequested)
                {
                    await ProcessOrganizations();
                    _openBankinService.Configuration = _openBankinService.Configuration with
                    {
                        LastSystemUpdate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
                    };

                    await UpdateConfiguration();
                    await Task.Delay(TimeSpan.FromMinutes(_openBankinService.Configuration.UpdateCycle));
                }
            }
            catch (Exception e)
            {
                ExecuteAsync(stoppingToken);
                Debug.WriteLine("O monitoramento foi finalizado!");
            }

        }

        private async Task LoadConfiguration()
        {
            string apiUrl = $"{UrlApiTeros}/worker/getconfiguration";

            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Carga das configurações no banco de dados com sucesso!: {responseData}");
                }
                else
                {
                    Console.WriteLine($"Falha ao carregar as configurações banco de dados: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
        }

        private async Task UpdateConfiguration()
        {
            string apiUrl = $"{UrlApiTeros}/SaveConfiguration";

            using (HttpClient httpClient = new HttpClient())
            {
                int UpdateCycle = -9999;
                string requestBody = (new { UpdateCycle }).SerializeJsonObject();
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
                HttpResponseMessage response = await httpClient.PostAsync(apiUrl, new StringContent(requestBody, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Atualização das configurações no banco de dados com sucesso!: {responseData}");
                }
                else
                {
                    Console.WriteLine($"Falha ao atualizar as configurações banco de dados: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
        }

        private async Task ProcessOrganizations()
        {
            try
            {
                using var httpClient = new HttpClient();
                var openBankingClient = new OpenBankingHttpClient(httpClient);

                var organizations = await openBankingClient.GetOrganizationsAsync(UrlOpenBanking);

                if (organizations != null)
                {
                    _openBankinService.Organizations = organizations;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro durante o processamento das organizações: {ex.Message}");
            }
        }
    }
}
