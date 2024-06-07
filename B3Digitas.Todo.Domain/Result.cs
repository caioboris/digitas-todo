namespace B3Digitas.Todo.Domain;

public class Result<T>
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
    public T? ResponseBody { get; set; }
    public Exception? Exception { get; set; }

    public static Result<T> Success(T data, string message = null)
    {
        return new Result<T>
        {
            IsSuccess = true,
            Message = message,
            ResponseBody = data
        };
    }

    public static Result<T> Failure(string message, Exception ex = null)
    {
        return new Result<T>
        {
            IsSuccess = false,
            Message = message,
            Exception = ex
        };
    }



}
