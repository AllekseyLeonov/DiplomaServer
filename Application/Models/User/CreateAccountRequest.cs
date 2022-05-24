namespace Application.Models.User;

public class CreateAccountRequest
{
    public string Name { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
}