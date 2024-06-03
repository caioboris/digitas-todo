namespace B3Digitas.Todo.Business;

public class Result
{
    public bool IsSucces {  get; set; }
    public object? ResultBody { get; set; }
    public Exception? Exception { get; set; }
}
