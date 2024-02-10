namespace TEROS.Application.Validation
{
    public class Result
    {
        public bool IsError { get; init; }
        public string Message { get; init; }
        public string Timestamp { get; init; }

        public static Result Ok()
            => new Result
            {
                IsError = false,
                Message = "OK",
                Timestamp = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
            };

        public static Result Failed(string message)
            => new Result
            {
                IsError = true,
                Message = message,
                Timestamp = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
            };

        public override string ToString()
            => (this.IsError ? "Failed" : "Succeeded") + $" with message {this.Message}.";
    }

    public class Result<T> : Result
    {
        public T Data { get; init; }

        public static Result<T> Ok(T data)
            => new Result<T>
            {
                Data = data,
                IsError = false,
                Message = "OK",
                Timestamp = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
            };

        public new static Result<T> Failed(string message)
            => new Result<T>
            {
                IsError = true,
                Message = message,
                Timestamp = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
            };

        public override string ToString()
            => (this.IsError ? "Failed" : "Succeeded") + $" with message {this.Message}.";
    }
}
