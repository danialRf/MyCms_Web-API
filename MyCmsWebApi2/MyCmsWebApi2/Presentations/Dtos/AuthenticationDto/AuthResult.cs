namespace MyCmsWebApi2.Presentations.Dtos.AuthenticationDto
{
    public class AuthResult
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public bool Result { get; set; }
        public List<string> Errors { get; set; }
    }
}
