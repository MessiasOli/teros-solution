using MediatR;
using Microsoft.EntityFrameworkCore;
using OneOf;
using TEROS.Application.Interfaces;
using TEROS.Domain.DTO;
using TEROS.Domain.Services;

namespace TEROS.Application.Commands
{
    public readonly record struct GetCreateDatabaseCommand : IReq<ConfigurationDTO> { }

    public class GetCreateDatabaseHandler : IHandler<GetCreateDatabaseCommand, ConfigurationDTO>
    {
        private readonly IMediator _mediator;
        private readonly IDataContext _dataContext;
        private readonly IOpenBankingService _openBankinService;

        public GetCreateDatabaseHandler(IDataContext dataContext, IOpenBankingService openBankinService, IMediator mediator)
        {
            _mediator = mediator;
            _dataContext = dataContext;
            _openBankinService = openBankinService;
        }

        public async Task<OneOf<ConfigurationDTO>> Handle(GetCreateDatabaseCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var now = DateTime.Now.ToString("yyyy/MM/dd");
                var lastVerification = await _dataContext.WatchfullAcess.Where(w => w.AccessTime == now).FirstOrDefaultAsync(cancellationToken);

                _openBankinService.Configuration = _openBankinService.Configuration with
                {
                    LastUpdate = lastVerification is not null ? lastVerification.AccessTime : "-",
                    StatusDatabase = Domain.Model.Enum.DatabaseStatus.Connected
                };
            }
            catch
            {
                _dataContext.Database.Migrate();
                var result = await _mediator.Send(new GetCreateDatabaseCommand { });
                return result.AsT0;
            }

            return new ConfigurationDTO(_openBankinService.Configuration);
        }
    }
}
