using TEROS.Domain.Model.OpenBanking;

namespace TEROS.Domain.DTO
{
    public readonly record struct OpenBankingDTO
    {
        public OpenBankingDTO(Organization organization) : this()
        {
            this.NomeEmpresa = organization.RegisteredName;
            this.Status = organization.Status;
            var autorization = organization.AuthorisationServers.Find(a => !string.IsNullOrEmpty(a.CustomerFriendlyLogoUri));
            if (autorization is not null)
            {
                this.Logo = autorization.CustomerFriendlyLogoUri;
                this.URLConfiguration = autorization.OpenIDDiscoveryDocument;
                this.Descricao = autorization.CustomerFriendlyDescription;
                this.NomeFantazia = autorization.CustomerFriendlyName;
            }
        }
        
        public string Status { get; init; }
        public string NomeEmpresa { get; init; }
        public string NomeFantazia { get; init; }
        public string Logo { get; init; }
        public string Descricao { get; init; }
        public string URLConfiguration { get; init; }
    }
}
