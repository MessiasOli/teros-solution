
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Data;
using TEROS.Domain.Model.Entities;

namespace TEROS.Application.Interfaces;

public interface IDataContext
{
    public DatabaseFacade Database { get; }
    DbSet<WatchfullAcessEntity> WatchfullAcess { get; set; }
    DbSet<ConfigurationEntity> Configurations { get; set; }
    DbSet<OpenBankingEntity> OpenBanking { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
