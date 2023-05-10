namespace MyCmsWebApi2.Infrastructure.Extensions
{
    public static class RandomStringGenerator
    {
        public static string RandomString(int lenght)
        {
            var random = new Random();
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890-!@#$%^&**()_+=:?><~`+";
            return new string(Enumerable.Repeat(chars, lenght).Select(s=>s[random.Next(s.Length)]).ToArray());
        }
    }
}
