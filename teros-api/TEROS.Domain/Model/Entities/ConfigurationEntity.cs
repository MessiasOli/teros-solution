using TEROS.Domain.Model.Enum;

namespace TEROS.Domain.Model.Entities
{
    public class ConfigurationEntity
    {
        public Guid Id { get; set; }
        public string LastSystemUpdate { get; set; }
        public string LastUpdate { get; set; }
        public DatabaseStatus StatusDatabase { get; set; }
    }
}
