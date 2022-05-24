namespace Application.Models.User;

public class CreateAccountResponse
{
    public bool IsSucceed { get; set; }
    public Core.User? User { get; set; }
}