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

        public DbSet<WatchfullAcess> WatchfullAcess { get; set; }
        DatabaseFacade IDataContext.Database { get => base.Database; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WatchfullAcess>().HasKey(w => new { w.Id });
        }
    } 
}