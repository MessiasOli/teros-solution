using TEROS.Domain.Model.OpenBanking;

namespace TEROS.Domain.DTO
{
    public readonly record struct OpenBankingDTO
    {
        public OpenBankingDTO(Organization organization, bool favorite) : this()
        {
            this.NomeEmpresa = organization.RegisteredName;
            this.Favorito = favorite;
            var autorization = organization.AuthorisationServers.Find(a => !string.IsNullOrEmpty(a.CustomerFriendlyLogoUri));
            if (autorization is not null)
            {
                this.Logo = autorization.CustomerFriendlyLogoUri;
                this.Descricao = autorization.CustomerFriendlyDescription;
                this.NomeFantasia = autorization.CustomerFriendlyName;
            }
            this.AuthorisationServersList = organization.AuthorisationServers.Select(o => new AuthorisationServersDTO(o)).ToList();
        }

        public bool Favorito { get; init; }
        public string NomeEmpresa { get; init; }
        public string NomeFantasia { get; init; }
        public string Logo { get; init; }
        public string Descricao { get; init; }
        public List<AuthorisationServersDTO> AuthorisationServersList { get; init; }
    }

    public readonly record struct AuthorisationServersDTO
    {
        public AuthorisationServersDTO(AuthorisationServer o) : this()
        {
            OpenIDDiscoveryDocument = o.OpenIDDiscoveryDocument ?? string.Empty;
            DeveloperPortalUri = o.DeveloperPortalUri;
            TermsOfServiceUri = o.TermsOfServiceUri;
        }

        public string OpenIDDiscoveryDocument { get; init; }
        public string DeveloperPortalUri { get; init; }
        public string TermsOfServiceUri { get; init; }
    }
}
