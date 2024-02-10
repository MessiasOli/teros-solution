namespace TEROS.Domain.Model
{
    public readonly record struct Message
    {
        public Message(string message)
        {
            Value = message;
        }

        public string Value { get; init; }
    }
}
