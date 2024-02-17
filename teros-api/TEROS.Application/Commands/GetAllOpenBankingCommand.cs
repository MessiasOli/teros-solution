using MediatR;
using OneOf;
using TEROS.Application.Interfaces;
using TEROS.Domain.DTO;
using TEROS.Domain.Services;

namespace TEROS.Application.Commands
{
    public readonly record struct GetAllOpenBankingCommand : IReq<ICollection<OpenBankingDTO>> { }

    public class GetAllOpenBankingHandler : IHandler<GetAllOpenBankingCommand, ICollection<OpenBankingDTO>>
    {
        private readonly IMediator _mediator;
        private readonly IOpenBankingService _openBankinService;

        public GetAllOpenBankingHandler(IOpenBankingService openBankinService, IMediator mediator)
        {
            _mediator = mediator;
            _openBankinService = openBankinService;
        }

        public async Task<OneOf<ICollection<OpenBankingDTO>>> Handle(GetAllOpenBankingCommand request, CancellationToken cancellationToken)
        {
            var organizationDto = new List<OpenBankingDTO>();

            foreach (var organization in _openBankinService.Organizations)
                organizationDto.Add(new OpenBankingDTO(organization));

            var updateDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            _openBankinService.Configuration = _openBankinService.Configuration with
            {
                LastUpdate = updateDate
            };

            await _mediator.Send(new SaveConfigurationCommand());

            return organizationDto;
        }
    }
}