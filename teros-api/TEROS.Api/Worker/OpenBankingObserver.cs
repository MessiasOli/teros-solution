using System.Diagnostics;
using System.Runtime.InteropServices;
using TEROS.Domain.Model.OpenBanking;
using TEROS.Domain.Services;

namespace TEROS.Application.Worker
{
    public class OpenBankingObserver : BackgroundService
    {
        public string UrlOpenBanking { get; init; }
        public List<Organization> Organizations { get; set; } = new();
        public DateTime LastSystemUpdate { get; set; }
        public DateTime LastFrontUpdate { get; set; }
        const int UPDATE_CYCLE = 45;

        IOpenBankingService OpenBankinService;

        public OpenBankingObserver(IConfiguration configuration, IOpenBankingService _openBankinService)
        {
            UrlOpenBanking = configuration["urlOpenBankingBrasil"];
            OpenBankinService = _openBankinService;
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            string step = "";
            Debug.WriteLine("Iniciando a tarefa de monitoramento...");

            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    await ProcessOrganizations();
                    OpenBankinService.Configuration = OpenBankinService.Configuration with
                    {
                        LastSystemUpdate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
                    };
                    await Task.Delay(TimeSpan.FromMinutes(UPDATE_CYCLE));
                }
            }
            catch (Exception e)
            {
                ExecuteAsync(stoppingToken);
                Debug.WriteLine("O monitoramento foi finalizado!");
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
                    Organizations = organizations;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro durante o processamento das organizações: {ex.Message}");
            }
        }

    }
}
