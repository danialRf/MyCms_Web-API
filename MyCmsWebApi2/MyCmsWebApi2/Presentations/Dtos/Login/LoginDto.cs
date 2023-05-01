using System.ComponentModel.DataAnnotations;

namespace MyCmsWebApi2.Presentations.Dtos.Login
{
    public class LoginDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
