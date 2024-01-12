namespace TABP.API.CQRS.Handlers
{
    public class Result<T>
    {
        public bool IsSuccess { get; }
        public string ErrorMessage { get; }
        public T Data { get; }

        private Result(bool isSuccess, string errorMessage, T data)
        {
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;
            Data = data;
        }

        public static Result<T> Success(T data) => new Result<T>(true, string.Empty, data);

        public static Result<T> Success() => new Result<T>(true, string.Empty, default);

        public static Result<T> Failure(string errorMessage) => new Result<T>(false, errorMessage, default);
    }
}
