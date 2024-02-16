using TEROS.Application.Commands;
using TEROS.Application.Queries;
using TEROS.Domain.Model;
using TEROS.Domain.Model.OpenBanking;

namespace TEROS.Api.Extensions;

public static class ConfigureEndpointsExtensions
{
    public static WebApplication ConfigureMinimalApiEndpoints(this WebApplication app)
    {
        app.Get<ApiRunningQuery, Message>("");
        app.Get<GetCreateDatabaseCommand, Configuration>("createDatabase");

        ConfigureWorker(app);
        return app;
    }

    public static void ConfigureWorker(this WebApplication app)
    {
        app.Get<GetConfigurationCommand, Configuration>("worker/getconfiguration");

    }
}
