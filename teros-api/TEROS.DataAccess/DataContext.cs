using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TEROS.Application.Interfaces;
using TEROS.Domain.Model.Entities;

namespace TEROS.DataAccess
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        DatabaseFacade IDataContext.Database { get => base.Database; }
        public DbSet<ConfigurationEntity> Configurations { get; set; }
        public DbSet<WatchfullAcessEntity> WatchfullAcess { get; set; }
        public DbSet<OpenBankingEntity> OpenBanking { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WatchfullAcessEntity>().HasKey(w => new { w.Id });
        }
    } 
}