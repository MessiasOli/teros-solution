using Microsoft.EntityFrameworkCore;
using OneOf;
using TEROS.Application.Interfaces;
using TEROS.Domain.Model.OpenBanking;
using TEROS.Domain.Services;

namespace TEROS.Application.Commands
{
    public readonly record struct GetConfigurationCommand : IReq<Configuration> { }

    public class GetConfigurationHandler : IHandler<GetConfigurationCommand, Configuration>
    {
        private readonly IDataContext _dataContext;
        private readonly IOpenBankingService _openBankinService;

        public GetConfigurationHandler(IDataContext dataContext, IOpenBankingService openBankinService)
        {
            _dataContext = dataContext;
            _openBankinService = openBankinService;
        }

        public async Task<OneOf<Configuration>> Handle(GetConfigurationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var now = DateTime.Now.ToString("yyyy/MM/dd");
                var lastVerification = _dataContext.WatchfullAcess.Where(w => w.AccessTime == now).FirstOrDefault();

                _openBankinService.Configuration = _openBankinService.Configuration with
                {
                    LastUpdate = lastVerification is not null ? lastVerification.AccessTime : "-",
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

            return _openBankinService.Configuration;
        }
    }
}
