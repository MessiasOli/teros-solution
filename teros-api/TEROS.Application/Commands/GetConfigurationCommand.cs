using Microsoft.EntityFrameworkCore;
using OneOf;
using TEROS.Application.Interfaces;
using TEROS.Domain.DTO;
using TEROS.Domain.Services;

namespace TEROS.Application.Commands
{
    public readonly record struct GetConfigurationCommand : IReq<ConfigurationDTO> { }

    public class GetConfigurationHandler : IHandler<GetConfigurationCommand, ConfigurationDTO>
    {
        private readonly IDataContext _dataContext;
        private readonly IOpenBankingService _openBankinService;

        public GetConfigurationHandler(IDataContext dataContext, IOpenBankingService openBankinService)
        {
            _dataContext = dataContext;
            _openBankinService = openBankinService;
        }

        public async Task<OneOf<ConfigurationDTO>> Handle(GetConfigurationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var lastVerification = await _dataContext.Configurations.FirstOrDefaultAsync(cancellationToken);

                _openBankinService.Configuration = _openBankinService.Configuration with
                {
                    LastUpdate = lastVerification is not null ? lastVerification.LastUpdate : "-",
                    StatusDatabase = Domain.Model.Enum.DatabaseStatus.Connected
                };
            }
            catch
            {
                _openBankinService.Configuration = _openBankinService.Configuration with
                {
                    StatusDatabase = Domain.Model.Enum.DatabaseStatus.Disconnected
                };
            }

            return new ConfigurationDTO(_openBankinService.Configuration);
        }
    }
}
