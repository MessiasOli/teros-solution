using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TEROS.Application.Interfaces;
using TEROS.Domain.Model.Entities;
using TEROS.Domain.Model.OpenBanking;

namespace TEROS.DataAccess
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<ConfigurationEntity> Configurations { get; set; }
        public DbSet<WatchfullAcessEntity> WatchfullAcess { get; set; }
        DatabaseFacade IDataContext.Database { get => base.Database; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WatchfullAcessEntity>().HasKey(w => new { w.Id });
        }
    } 
}