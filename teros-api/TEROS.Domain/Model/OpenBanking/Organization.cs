namespace TEROS.Domain.Model.OpenBanking
{
    public class Organization
    {
        public string OrganisationId { get; init; }
        public string Status { get; init; }
        public string OrganisationName { get; init; }
        public DateTime CreatedOn { get; init; }
        public string LegalEntityName { get; init; }
        public string CountryOfRegistration { get; init; }
        public string CompanyRegister { get; init; }
        public List<string> Tags { get; init; }
        public object Size { get; init; }
        public string RegistrationNumber { get; init; }
        public string RegistrationId { get; init; }
        public string RegisteredName { get; init; }
        public string AddressLine1 { get; init; }
        public string AddressLine2 { get; init; }
        public string City { get; init; }
        public string Postcode { get; init; }
        public string Country { get; init; }
        public string ParentOrganisationReference { get; init; }
        public List<AuthorisationServer> AuthorisationServers { get; init; }
        public List<OrgDomainClaim> OrgDomainClaims { get; init; }
        public List<OrgDomainRoleClaim> OrgDomainRoleClaims { get; init; }
    }

    public class ApiDiscoveryEndpoint
    {
        public string ApiDiscoveryId { get; init; }
        public string ApiEndpoint { get; init; }
    }

    public class ApiResource
    {
        public string ApiResourceId { get; init; }
        public string ApiVersion { get; init; }
        public bool FamilyComplete { get; init; }
        public string ApiCertificationUri { get; init; }
        public string CertificationStatus { get; init; }
        public string CertificationStartDate { get; init; }
        public string CertificationExpirationDate { get; init; }
        public string ApiFamilyType { get; init; }
        public List<ApiDiscoveryEndpoint> ApiDiscoveryEndpoints { get; init; }
    }

    public class AuthorisationServerCertification
    {
        public string CertificationStartDate { get; init; }
        public string CertificationExpirationDate { get; init; }
        public string CertificationId { get; init; }
        public string AuthorisationServerId { get; init; }
        public string Status { get; init; }
        public string ProfileVariant { get; init; }
        public string ProfileType { get; init; }
        public double ProfileVersion { get; init; }
        public string CertificationURI { get; init; }
    }

    public class AuthorisationServer
    {
        public string AuthorisationServerId { get; init; }
        public bool AutoRegistrationSupported { get; init; }
        public object AutoRegistrationNotificationWebhook { get; init; }
        public bool SupportsCiba { get; init; }
        public bool SupportsDCR { get; init; }
        public bool SupportsRedirect { get; init; }
        public string CustomerFriendlyDescription { get; init; }
        public string CustomerFriendlyLogoUri { get; init; }
        public string CustomerFriendlyName { get; init; }
        public string DeveloperPortalUri { get; init; }
        public string TermsOfServiceUri { get; init; }
        public object NotificationWebhookAddedDate { get; init; }
        public string OpenIDDiscoveryDocument { get; init; }
        public string Issuer { get; init; }
        public object FederationId { get; init; }
        public object FederationEndpoint { get; init; }
        public string PayloadSigningCertLocationUri { get; init; }
        public double CreatedAt { get; init; }
        public object ParentAuthorisationServerId { get; init; }
        public object DeprecatedDate { get; init; }
        public object RetirementDate { get; init; }
        public object SupersededByAuthorisationServerId { get; init; }
        public List<ApiResource> ApiResources { get; init; }
        public List<AuthorisationServerCertification> AuthorisationServerCertifications { get; init; }
    }

    public class OrgDomainClaim
    {
        public string AuthorisationDomainName { get; init; }
        public string AuthorityName { get; init; }
        public string RegistrationId { get; init; }
        public string Status { get; init; }
    }

    public class OrgDomainRoleClaim
    {
        public string Status { get; init; }
        public string AuthorisationDomain { get; init; }
        public string Role { get; init; }
        public string RegistrationId { get; init; }
        public List<object> Authorisations { get; init; }
        public string RoleType { get; init; }
        public bool Exclusive { get; init; }
        public List<object> Metadata { get; init; }
    }
}
