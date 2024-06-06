namespace B3Digitas.Todo.Api.DTOs;

public record UserLoginDTO
{
    public string Username { get; set; }
    public string Password { get; set; }
}
