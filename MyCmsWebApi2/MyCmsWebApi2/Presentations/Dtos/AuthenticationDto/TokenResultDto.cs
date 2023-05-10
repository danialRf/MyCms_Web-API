using System.ComponentModel.DataAnnotations;

namespace MyCmsWebApi2.Presentations.Dtos
{
    public class TokenResultDto
    {
        [Required]
        public string Token { get; set; }
        [Required]
        public string RefreshToken { get; set; }

    }
}
