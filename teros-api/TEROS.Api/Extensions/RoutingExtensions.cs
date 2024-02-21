using TEROS.Domain.Interfaces;
using TEROS.Api.Controllers;
using TEROS.Application.Interfaces;
using MediatR;

namespace TEROS.Api.Extensions;

public static class RoutingExtensions
{
    #region Get
    public static RouteHandlerBuilder Get<TRequest, TResult>(this WebApplication app, string route)
        where TRequest : IReq<TResult>
    {
        return app.MapGet($"api/{route}", async (IMediator mediator, [AsParameters] TRequest request) => (await mediator.Send(request)).MatchMinimalResponse()).WithTags(GerarTagPelaRota(route));
    }
    public static RouteHandlerBuilder Get<TRequest, TResult, E1>(this WebApplication app, string route)
        where TRequest : IReq<TResult, E1>
        where E1 : IValidationError
    {
        return app.MapGet($"api/{route}", async (IMediator mediator, [AsParameters] TRequest request) => (await mediator.Send(request)).MatchMinimalResponse()).WithTags(GerarTagPelaRota(route));
    }
    public static RouteHandlerBuilder Get<TRequest, TResult, E1, E2>(this WebApplication app, string route)
        where TRequest : IReq<TResult, E1, E2>
        where E1 : IValidationError
        where E2 : IValidationError
    {
        return app.MapGet($"api/{route}", async (IMediator mediator, [AsParameters] TRequest request) => (await mediator.Send(request)).MatchMinimalResponse()).WithTags(GerarTagPelaRota(route));
    }
    public static RouteHandlerBuilder Get<TRequest, TResult, E1, E2, E3>(this WebApplication app, string route)
        where TRequest : IReq<TResult, E1, E2, E3>
        where E1 : IValidationError
        where E2 : IValidationError
        where E3 : IValidationError
    {
        return app.MapGet($"api/{route}", async (IMediator mediator, [AsParameters] TRequest request) => (await mediator.Send(request)).MatchMinimalResponse()).WithTags(GerarTagPelaRota(route));
    }
    #endregion

    #region Post
    public static RouteHandlerBuilder Post<TRequest, TResult>(this WebApplication app, string route)
       where TRequest : IReq<TResult>
    {
        return app.MapPost($"api/{route}", async (IMediator mediator, TRequest request) => (await mediator.Send(request)).MatchMinimalResponse()).WithTags(GerarTagPelaRota(route));
    }
    public static RouteHandlerBuilder Post<TRequest, TResult, E1>(this WebApplication app, string route)
        where TRequest : IReq<TResult, E1>
        where E1 : IValidationError
    {
        return app.MapPost($"api/{route}", async (IMediator mediator, TRequest request) => (await mediator.Send(request)).MatchMinimalResponse()).WithTags(GerarTagPelaRota(route));
    }
    public static RouteHandlerBuilder Post<TRequest, TResult, E1, E2>(this WebApplication app, string route)
        where TRequest : IReq<TResult, E1, E2>
        where E1 : IValidationError
        where E2 : IValidationError
    {
        return app.MapPost($"api/{route}", async (IMediator mediator, TRequest request) => (await mediator.Send(request)).MatchMinimalResponse()).WithTags(GerarTagPelaRota(route));
    }
    public static RouteHandlerBuilder Post<TRequest, TResult, E1, E2, E3>(this WebApplication app, string route)
        where TRequest : IReq<TResult, E1, E2, E3>
        where E1 : IValidationError
        where E2 : IValidationError
        where E3 : IValidationError
    {
        return app.MapPost($"api/{route}", async (IMediator mediator, TRequest request) => (await mediator.Send(request)).MatchMinimalResponse()).WithTags(GerarTagPelaRota(route));
    }
    #endregion

    #region Put
    public static RouteHandlerBuilder Put<TRequest, TResult>(this WebApplication app, string route)
       where TRequest : IReq<TResult>
    {
        return app.MapPut($"api/{route}", async (IMediator mediator, TRequest request) => (await mediator.Send(request)).MatchMinimalResponse()).WithTags(GerarTagPelaRota(route));
    }
    public static RouteHandlerBuilder Put<TRequest, TResult, E1>(this WebApplication app, string route)
        where TRequest : IReq<TResult, E1>
        where E1 : IValidationError
    {
        return app.MapPut($"api/{route}", async (IMediator mediator, TRequest request) => (await mediator.Send(request)).MatchMinimalResponse()).WithTags(GerarTagPelaRota(route));
    }
    public static RouteHandlerBuilder Put<TRequest, TResult, E1, E2>(this WebApplication app, string route)
        where TRequest : IReq<TResult, E1, E2>
        where E1 : IValidationError
        where E2 : IValidationError
    {
        return app.MapPut($"api/{route}", async (IMediator mediator, TRequest request) => (await mediator.Send(request)).MatchMinimalResponse()).WithTags(GerarTagPelaRota(route));
    }
    public static RouteHandlerBuilder Put<TRequest, TResult, E1, E2, E3>(this WebApplication app, string route)
        where TRequest : IReq<TResult, E1, E2, E3>
        where E1 : IValidationError
        where E2 : IValidationError
        where E3 : IValidationError
    {
        return app.MapPut($"api/{route}", async (IMediator mediator, TRequest request) => (await mediator.Send(request)).MatchMinimalResponse()).WithTags(GerarTagPelaRota(route));
    }
    #endregion

    #region Delete
    public static RouteHandlerBuilder Delete<TRequest, TResult>(this WebApplication app, string route)
       where TRequest : IReq<TResult>
    {
        return app.MapDelete($"api/{route}", async (IMediator mediator, [AsParameters] TRequest request) => (await mediator.Send(request)).MatchMinimalResponse()).WithTags(GerarTagPelaRota(route));
    }
    public static RouteHandlerBuilder Delete<TRequest, TResult, E1>(this WebApplication app, string route)
        where TRequest : IReq<TResult, E1>
        where E1 : IValidationError
    {
        return app.MapDelete($"api/{route}", async (IMediator mediator, [AsParameters] TRequest request) => (await mediator.Send(request)).MatchMinimalResponse()).WithTags(GerarTagPelaRota(route));
    }
    public static RouteHandlerBuilder Delete<TRequest, TResult, E1, E2>(this WebApplication app, string route)
        where TRequest : IReq<TResult, E1, E2>
        where E1 : IValidationError
        where E2 : IValidationError
    {
        return app.MapDelete($"api/{route}", async (IMediator mediator, [AsParameters] TRequest request) => (await mediator.Send(request)).MatchMinimalResponse()).WithTags(GerarTagPelaRota(route));
    }
    public static RouteHandlerBuilder Delete<TRequest, TResult, E1, E2, E3>(this WebApplication app, string route)
        where TRequest : IReq<TResult, E1, E2, E3>
        where E1 : IValidationError
        where E2 : IValidationError
        where E3 : IValidationError
    {
        return app.MapDelete($"api/{route}", async (IMediator mediator, [AsParameters] TRequest request) => (await mediator.Send(request)).MatchMinimalResponse()).WithTags(GerarTagPelaRota(route));
    }
    #endregion

    private static string GerarTagPelaRota(string route)
    {
        return route.Split("/")[0].Replace("-", "_");
    }
}
