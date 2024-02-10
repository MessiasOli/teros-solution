using TEROS.Api.Extensions;
using TEROS.Application.Queries;
using TEROS.Domain.Model;

namespace TEROS.Api.Extensions;

public static class ConfigureEndpointsExtensions
{
    public static WebApplication ConfigureMinimalApiEndpoints(this WebApplication app)
    {
        app.Get<ApiRunningQuery, Message>("");

        return app;
    }
}
