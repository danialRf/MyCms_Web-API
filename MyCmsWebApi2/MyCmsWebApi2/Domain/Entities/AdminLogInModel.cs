namespace MyCmsWebApi2.Domain.Entities;

public class AdminLogIn
{
    public int Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Passwords { get; set; } = string.Empty;
}