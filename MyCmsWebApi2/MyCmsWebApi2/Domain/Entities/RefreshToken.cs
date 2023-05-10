namespace MyCmsWebApi2.Domain.Entities
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Token { get; set; } = string.Empty;
        public string JwtId { get; set; }
        public bool IsUsed { get; set; }
        public bool IsRevoked { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Expires { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}
