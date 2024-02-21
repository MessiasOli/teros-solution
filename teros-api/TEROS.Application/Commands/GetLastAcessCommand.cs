using OneOf;
using TEROS.Application.Interfaces;
using TEROS.Domain.DTO;
using TEROS.Domain.Services;

namespace TEROS.Application.Commands
{
    public readonly record struct GetLastAcessCommand : IReq<MessageDTO> {}


    public class GetLastAcessHandler : IHandler<GetLastAcessCommand, MessageDTO>
    {
        private readonly IOpenBankingService _openBankinService;
        private readonly ICalculateTimeService _calculateTimeService;

        public GetLastAcessHandler(ICalculateTimeService calculateTimeService, IOpenBankingService openBankinService)
        {
            _openBankinService = openBankinService;
            _calculateTimeService = calculateTimeService;
        }

        public async Task<OneOf<MessageDTO>> Handle(GetLastAcessCommand request, CancellationToken cancellationToken)
        {
            var result = _calculateTimeService.GetLastTime(_openBankinService.Configuration.LastUpdate, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            return new MessageDTO() { Value = result };
        }
    }
}
