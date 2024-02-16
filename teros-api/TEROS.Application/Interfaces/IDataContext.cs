
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TEROS.Domain.Model.Entities;

namespace TEROS.Application.Interfaces;

public interface IDataContext
{
    public DatabaseFacade Database { get; }
    DbSet<WatchfullAcess> WatchfullAcess { get; set; }
}
