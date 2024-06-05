namespace B3Digitas.Todo.Domain;

public class Result<T>
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
    public T? ResponseBody { get; set; }
    public Exception? Exception { get; set; }
}
