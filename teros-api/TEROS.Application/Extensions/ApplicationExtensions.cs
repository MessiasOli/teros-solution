using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CTEEP.DDM.Application.Extensions;

public static class ApplicationExtensions
{
    public static IServiceCollection ConfigureAppServices(this IServiceCollection services)
    {
        //services.AddSingleton<IIEC60826PressaoVentoService, IEC60826PressaoVentoService>();

        return services;
    }
}
