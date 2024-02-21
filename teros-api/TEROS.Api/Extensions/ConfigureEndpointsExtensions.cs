using TEROS.Application.Commands;
using TEROS.Application.Queries;
using TEROS.Domain.DTO;
using TEROS.Domain.Model.Entities;

namespace TEROS.Api.Extensions;

public static class ConfigureEndpointsExtensions
{
    public static WebApplication ConfigureMinimalApiEndpoints(this WebApplication app)
    {
        app.Get<ApiRunningQuery, MessageDTO>("");
        app.Get<GetCreateDatabaseCommand, ConfigurationDTO>("createDatabase");
        app.Get<GetAllOpenBankingCommand, ICollection<OpenBankingDTO>>("GetAllOpenBanking");
        app.Post<FavoriteOpenBankingCommand, bool>("FavoriteOpenBanking");
        app.Post<SaveConfigurationCommand, ConfigurationEntity>("SaveConfiguration");
        app.Get<GetLastAcessCommand, MessageDTO>("getLastAccess");

        ConfigureWorker(app);
        return app;
    }

    public static void ConfigureWorker(this WebApplication app)
    {
        app.Get<GetConfigurationCommand, ConfigurationDTO>("worker/getconfiguration");

    }
}
