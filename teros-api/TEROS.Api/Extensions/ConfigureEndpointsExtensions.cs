using TEROS.Application.Commands;
using TEROS.Application.Queries;
using TEROS.Domain.DTO;
using TEROS.Domain.Model;

namespace TEROS.Api.Extensions;

public static class ConfigureEndpointsExtensions
{
    public static WebApplication ConfigureMinimalApiEndpoints(this WebApplication app)
    {
        app.Get<ApiRunningQuery, Message>("");
        app.Get<GetCreateDatabaseCommand, ConfigurationDTO>("createDatabase");
        app.Get<GetAllOpenBankingCommand, ICollection<OpenBankingDTO>>("GetAllOpenBanking");
        app.Post<FavoriteOpenBankingCommand, bool>("FavoriteOpenBanking");

        ConfigureWorker(app);
        return app;
    }

    public static void ConfigureWorker(this WebApplication app)
    {
        app.Get<GetConfigurationCommand, ConfigurationDTO>("worker/getconfiguration");

    }
}
