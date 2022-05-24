namespace Application.Models.User;

public class LoginResponse
{
    public bool IsSucceed { get; set; }
    public Core.User? User { get; set; }
}