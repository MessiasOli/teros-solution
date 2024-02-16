using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OneOf;
using TEROS.Application.Interfaces;
using TEROS.Domain.Model.OpenBanking;
using TEROS.Domain.Services;

namespace TEROS.Application.Commands
{
    public readonly record struct GetCreateDatabaseCommand : IReq<Configuration> { }

    public class GetCreateDatabaseHandler : IHandler<GetCreateDatabaseCommand, Configuration>
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

        public async Task<OneOf<Configuration>> Handle(GetCreateDatabaseCommand request, CancellationToken cancellationToken)
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
                _dataContext.Database.Migrate();
                var result = await _mediator.Send(new GetCreateDatabaseCommand { });
                return result.AsT0;
            }

            return _openBankinService.Configuration;
        }
    }
}
