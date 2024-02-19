using MediatR;
using OneOf;
using TEROS.Application.Interfaces;
using TEROS.Domain.DTO;
using TEROS.Domain.Model.Entities;
using TEROS.Domain.Model.OpenBanking;
using TEROS.Domain.Services;

namespace TEROS.Application.Commands
{
    public readonly record struct GetAllOpenBankingCommand : IReq<ICollection<OpenBankingDTO>> { }

    public class GetAllOpenBankingHandler : IHandler<GetAllOpenBankingCommand, ICollection<OpenBankingDTO>>
    {
        private readonly IMediator _mediator;
        private readonly IOpenBankingService _openBankinService;
        private readonly IDataContext _dataContext;

        public GetAllOpenBankingHandler(IDataContext dataContext, IOpenBankingService openBankinService, IMediator mediator)
        {
            _mediator = mediator;
            _openBankinService = openBankinService;
            _dataContext = dataContext;
        }

        public async Task<OneOf<ICollection<OpenBankingDTO>>> Handle(GetAllOpenBankingCommand request, CancellationToken cancellationToken)
        {
            var openBankingList = _dataContext.OpenBanking.ToList();
            var organizationDto = new List<OpenBankingDTO>();

            foreach (var organization in _openBankinService.Organizations)
            {
                bool favorite = CheckFavoriteActive(openBankingList, organization);
                organizationDto.Add(new OpenBankingDTO(organization, favorite));
            }

            _openBankinService.Configuration = _openBankinService.Configuration with
            {
                LastUpdate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
            };

            await _mediator.Send(new SaveConfigurationCommand());

            return organizationDto.OrderBy(o => o.NomeFantasia).ThenBy(o => o.Favorito).ToList();
        }

        private static bool CheckFavoriteActive(List<OpenBankingEntity> openBankingList, Organization organization)
        {
            bool favorite = false;
            if (organization.AuthorisationServers.Count > 0)
            {
                var ob = openBankingList.Where(o => organization.AuthorisationServers
                                                                .Find(a => a.CustomerFriendlyName == o.CustomerFriendlyName) is not null)
                                        .FirstOrDefault();

                favorite = ob is not null ? ob.Favorite : false;
            }

            return favorite;
        }
    }
}