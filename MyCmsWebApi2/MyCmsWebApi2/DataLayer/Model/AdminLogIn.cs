namespace MyCmsWebApi.Models;

public class AdminLogIn
{
    public int LoginId { get; set; }
    public string UserName { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    public string Passwords { get; set; } = String.Empty;
}