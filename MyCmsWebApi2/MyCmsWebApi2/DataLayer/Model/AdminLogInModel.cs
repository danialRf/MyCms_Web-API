namespace MyCmsWebApi2.DataLayer.Model;

public class AdminLogIn
{
    public int Id { get; set; }
    public string UserName { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    public string Passwords { get; set; } = String.Empty;
}