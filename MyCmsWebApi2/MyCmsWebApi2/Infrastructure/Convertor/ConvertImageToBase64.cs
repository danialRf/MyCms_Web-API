namespace MyCmsWebApi2.Infrastructure.Convertor
{
    public static class ConvertImageToBase64
    {
        public static string ImageToBase64(this IFormFile file)
        {
            using var memoryStream = new MemoryStream();
            file.CopyTo(memoryStream);
            var bytes = memoryStream.ToArray();
            var base64 = Convert.ToBase64String(bytes);
            return base64.ToString();
        }
    }
}
