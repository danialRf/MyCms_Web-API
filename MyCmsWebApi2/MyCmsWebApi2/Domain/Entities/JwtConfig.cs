namespace MyCmsWebApi2.Domain.Entities
{
    public class JwtConfig
    {
        public string Secret { get; set; }
        public TimeSpan ExpiryTimeFrame { get; set; }
    }
}
