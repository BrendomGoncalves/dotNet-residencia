namespace MvcMovie.Models;

public class User
{
    public required int UserId { get; set; }
    public string? Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
}