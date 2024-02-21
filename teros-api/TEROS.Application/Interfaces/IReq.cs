using TEROS.Domain.Interfaces;
using MediatR;
using OneOf;

namespace TEROS.Application.Interfaces;

public interface IReq<Result>
    : IRequest<OneOf<Result>>
{
}

public interface IReq<Result, Error1>
    : IRequest<OneOf<Result, Error1>>
    where Error1 : IValidationError
{
}

public interface IReq<Result, Error1, Error2>
    : IRequest<OneOf<Result, Error1, Error2>>
    where Error1 : IValidationError
    where Error2 : IValidationError
{
}

public interface IReq<Result, Error1, Error2, Error3>
    : IRequest<OneOf<Result, Error1, Error2, Error3>>
    where Error1 : IValidationError
    where Error2 : IValidationError
    where Error3 : IValidationError
{
}

public interface IReq<Result, Error1, Error2, Error3, Error4>
    : IRequest<OneOf<Result, Error1, Error2, Error3, Error4>>
    where Error1 : IValidationError
    where Error2 : IValidationError
    where Error3 : IValidationError
    where Error4 : IValidationError
{
}

public interface IReq<Result, Error1, Error2, Error3, Error4, Error5>
    : IRequest<OneOf<Result, Error1, Error2, Error3, Error4, Error5>>
    where Error1 : IValidationError
    where Error2 : IValidationError
    where Error3 : IValidationError
    where Error4 : IValidationError
    where Error5 : IValidationError
{
}
