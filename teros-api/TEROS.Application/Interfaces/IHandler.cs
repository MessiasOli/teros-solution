using MediatR;
using OneOf;
using TEROS.Domain.Interfaces;

namespace TEROS.Application.Interfaces;

public interface IHandler<Command, Result>
    : IRequestHandler<Command, OneOf<Result>>
    where Command : struct, IReq<Result>
{
}

public interface IHandler<Command, Result, Error1>
    : IRequestHandler<Command, OneOf<Result, Error1>>
    where Command : struct, IReq<Result, Error1>
    where Error1 : IValidationError
{
}

public interface IHandler<Command, Result, Error1, Error2>
    : IRequestHandler<Command, OneOf<Result, Error1, Error2>>
    where Command : struct, IReq<Result, Error1, Error2>
    where Error1 : IValidationError
    where Error2 : IValidationError
{
}

public interface IHandler<Command, Result, Error1, Error2, Error3>
    : IRequestHandler<Command, OneOf<Result, Error1, Error2, Error3>>
    where Command : struct, IReq<Result, Error1, Error2, Error3>
    where Error1 : IValidationError
    where Error2 : IValidationError
    where Error3 : IValidationError
{
}

public interface IHandler<Command, Result, Error1, Error2, Error3, Error4>
    : IRequestHandler<Command, OneOf<Result, Error1, Error2, Error3, Error4>>
    where Command : struct, IReq<Result, Error1, Error2, Error3, Error4>
    where Error1 : IValidationError
    where Error2 : IValidationError
    where Error3 : IValidationError
    where Error4 : IValidationError
{
}

public interface IHandler<Command, Result, Error1, Error2, Error3, Error4, Error5>
    : IRequestHandler<Command, OneOf<Result, Error1, Error2, Error3, Error4, Error5>>
    where Command : struct, IReq<Result, Error1, Error2, Error3, Error4, Error5>
    where Error1 : IValidationError
    where Error2 : IValidationError
    where Error3 : IValidationError
    where Error4 : IValidationError
    where Error5 : IValidationError
{
}
