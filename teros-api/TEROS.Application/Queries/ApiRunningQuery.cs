using OneOf;
using TEROS.Application.Interfaces;
using TEROS.Domain.DTO;

namespace TEROS.Application.Queries;

public readonly record struct ApiRunningQuery : IReq<MessageDTO> { }

public class ApiRunningHandler : IHandler<ApiRunningQuery, MessageDTO>
{
    public async Task<OneOf<MessageDTO>> Handle(ApiRunningQuery request, CancellationToken cancellationToken)
    {
        return new MessageDTO("TEROS API is running.");
    }
}
