using MediatR;
using System.Diagnostics;
using TEROS.Application.Commands;
using TEROS.Domain.Services;

namespace TEROS.Application.Worker
{
    public class OpenBankingObserver : BackgroundService
    {
        public string UrlOpenBanking { get; init; }
        public DateTime LastSystemUpdate { get; set; }
        public DateTime LastFrontUpdate { get; set; }
        const int UPDATE_CYCLE = 45;

        private IOpenBankingService _openBankinService;
        private IMediator _mediator;

        public OpenBankingObserver(IConfiguration configuration, IOpenBankingService openBankinService, IMediator mediator)
        {
            UrlOpenBanking = configuration["urlOpenBankingBrasil"];
            _openBankinService = openBankinService;
            _mediator = mediator;
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
                    _openBankinService.Configuration = _openBankinService.Configuration with
                    {
                        LastSystemUpdate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
                    };
                    //await _mediator.Send(new SaveConfigurationCommand());

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
