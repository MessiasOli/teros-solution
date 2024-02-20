using Microsoft.EntityFrameworkCore;
using OneOf;
using TEROS.Application.Interfaces;
using TEROS.Domain.Model.Entities;
using TEROS.Domain.Services;

namespace TEROS.Application.Commands
{
    public readonly record struct SaveConfigurationCommand : IReq<ConfigurationEntity> 
    {
        public int UpdateCycle { get; init; }
    }

    public class SaveConfigurationHandler : IHandler<SaveConfigurationCommand, ConfigurationEntity>
    {
        private readonly IDataContext _dataContext;
        private readonly IOpenBankingService _openBankinService;

        public SaveConfigurationHandler(IDataContext dataContext, IOpenBankingService openBankinService)
        {
            _dataContext = dataContext;
            _openBankinService = openBankinService;
        }

        public async Task<OneOf<ConfigurationEntity>> Handle(SaveConfigurationCommand request, CancellationToken cancellationToken)
        {
            ConfigurationEntity configuration = await _dataContext.Configurations.FirstOrDefaultAsync(cancellationToken);
            if (configuration != null)
            {
                configuration.LastUpdate = _openBankinService.Configuration.LastUpdate;
                configuration.UpdateCycle = request.UpdateCycle is not -9999 ? request.UpdateCycle : configuration.UpdateCycle;
                _dataContext.Configurations.Update(configuration);
            }
            else
            {
                configuration = new() { 
                    Id = Guid.NewGuid(),
                    LastSystemUpdate = _openBankinService.Configuration.LastSystemUpdate,
                    LastUpdate = _openBankinService.Configuration.LastUpdate,
                    StatusDatabase = _openBankinService.Configuration.StatusDatabase,
                    UpdateCycle = request.UpdateCycle is not -9999 ? request.UpdateCycle : 15
                };
                _dataContext.Configurations.Add(configuration);
            }

            await _dataContext.SaveChangesAsync(cancellationToken);
            return configuration;
        }
    }
}
