using TEROS.Domain.Model.OpenBanking;

namespace TEROS.Domain.Services
{
    public interface IOpenBankingService
    {
        public Configuration Configuration { get; set; }
        public ICollection<Organization> Organizations { get; set; }
    }
}
