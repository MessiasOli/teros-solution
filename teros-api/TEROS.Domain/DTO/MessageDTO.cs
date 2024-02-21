namespace TEROS.Domain.DTO
{
    public readonly record struct MessageDTO
    {
        public MessageDTO(string message)
        {
            Value = message;
        }

        public string Value { get; init; }
    }
}
