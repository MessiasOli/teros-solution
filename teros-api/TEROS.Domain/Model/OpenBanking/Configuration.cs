using TEROS.Domain.Model.Enum;

namespace TEROS.Domain.Model.OpenBanking
{
    public readonly record struct Configuration
    {
        public string LastSystemUpdate { get; init; }
        public string LastUpdate { get; init; }
        public int UpdateCycle { get; init; }
        public DatabaseStatus StatusDatabase { get; init; }
    }
}
