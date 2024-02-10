using OneOf;
using TEROS.Application.Interfaces;
using TEROS.Domain.Model;

namespace TEROS.Application.Queries;

public readonly record struct ApiRunningQuery : IReq<Message> { }

public class ApiRunningHandler : IHandler<ApiRunningQuery, Message>
{
    public async Task<OneOf<Message>> Handle(ApiRunningQuery request, CancellationToken cancellationToken)
    {
        return new Message("TEROS API is running.");
    }
}
