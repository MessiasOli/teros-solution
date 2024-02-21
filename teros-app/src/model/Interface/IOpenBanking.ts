export interface IOpenBanking {
    favorito : boolean;
    nomeEmpresa: string;
    nomeFantasia: string;
    logo: string;
    descricao: string;
    authorisationServersList: IAuthorisationServers[];
}

export interface IAuthorisationServers {
    openIDDiscoveryDocument: string;
    developerPortalUri: string;
    TermsOfServiceUri: string;
}
