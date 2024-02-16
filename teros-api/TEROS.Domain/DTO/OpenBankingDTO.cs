namespace TEROS.Domain.DTO
{
    public readonly record struct OpenBankingDTO
    {
        public string Nome { get; init; }
        public string Logo { get; init; }
        public string URLConfiguration { get; init; }
    }
}
