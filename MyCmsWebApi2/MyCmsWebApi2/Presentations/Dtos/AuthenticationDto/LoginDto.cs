using System.ComponentModel.DataAnnotations;

namespace MyCmsWebApi2.Presentations.Dtos.AuthenticationDto
{
    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
