using TEROS.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using OneOf;
using TEROS.Application.Validation;

namespace TEROS.Api.Controllers;

public static class ResponseExtensions
{
    public static IActionResult MatchResponse<T1>(this OneOf<T1> oneOf)
    {
        return oneOf.Match(
            MatchValidationError
        );
    }
    public static IActionResult MatchResponse<T1, T2>(this OneOf<T1, T2> oneOf)
    {
        return oneOf.Match(
            MatchValidationError,
            MatchValidationError
        );
    }
    public static IActionResult MatchResponse<T1, T2, T3>(this OneOf<T1, T2, T3> oneOf)
    {
        return oneOf.Match(
            MatchValidationError,
            MatchValidationError,
            MatchValidationError
        );
    }
    public static IActionResult MatchResponse<T1, T2, T3, T4>(this OneOf<T1, T2, T3, T4> oneOf)
    {
        return oneOf.Match(
            MatchValidationError,
            MatchValidationError,
            MatchValidationError,
            MatchValidationError
        );
    }

    public static IActionResult MatchResponse<T1, T2, T3, T4, T5>(this OneOf<T1, T2, T3, T4, T5> oneOf)
    {
        return oneOf.Match(
            MatchValidationError,
            MatchValidationError,
            MatchValidationError,
            MatchValidationError,
            MatchValidationError
        );
    }

    public static IActionResult MatchResponse<T1, T2, T3, T4, T5, T6>(this OneOf<T1, T2, T3, T4, T5, T6> oneOf)
    {
        return oneOf.Match(
            MatchValidationError,
            MatchValidationError,
            MatchValidationError,
            MatchValidationError,
            MatchValidationError,
            MatchValidationError
        );
    }

    public static IActionResult MatchResponse<T1, T2, T3, T4, T5, T6, T7>(this OneOf<T1, T2, T3, T4, T5, T6, T7> oneOf)
    {
        return oneOf.Match(
            MatchValidationError,
            MatchValidationError,
            MatchValidationError,
            MatchValidationError,
            MatchValidationError,
            MatchValidationError,
            MatchValidationError
        );
    }


    private static IActionResult MatchValidationError<T>(T t)
    {
        return t is IValidationError validationError
            ? new BadRequestObjectResult(Result<IValidationError>.Failed(validationError.Message))
            : (IActionResult)new OkObjectResult(Result<T>.Ok(t));
    }

    private static IResult MatchMinimalValidationError<T>(T t)
    {
        return t is IValidationError validationError
            ? Results.BadRequest(Result<IValidationError>.Failed(validationError.Message))
            : Results.Ok(Result<T>.Ok(t));
    }

    public static IResult MatchMinimalResponse<T1>(this OneOf<T1> oneOf)
    {
        return oneOf.Match(
            MatchMinimalValidationError
        );
    }

    public static IResult MatchMinimalResponse<T1, T2>(this OneOf<T1, T2> oneOf)
    {
        return oneOf.Match(
            MatchMinimalValidationError,
            MatchMinimalValidationError
        );
    }

    public static IResult MatchMinimalResponse<T1, T2, T3>(this OneOf<T1, T2, T3> oneOf)
    {
        return oneOf.Match(
            MatchMinimalValidationError,
            MatchMinimalValidationError,
            MatchMinimalValidationError
        );
    }

    public static IResult MatchMinimalResponse<T1, T2, T3, T4>(this OneOf<T1, T2, T3, T4> oneOf)
    {
        return oneOf.Match(
            MatchMinimalValidationError,
            MatchMinimalValidationError,
            MatchMinimalValidationError,
            MatchMinimalValidationError
        );
    }

    public static IResult MatchMinimalResponse<T1, T2, T3, T4, T5>(this OneOf<T1, T2, T3, T4, T5> oneOf)
    {
        return oneOf.Match(
            MatchMinimalValidationError,
            MatchMinimalValidationError,
            MatchMinimalValidationError,
            MatchMinimalValidationError,
            MatchMinimalValidationError
        );
    }
}
