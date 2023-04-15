using System.Drawing;

namespace MyCmsWebApi2.Infrastructure.Convertor
{
    public static class ConvertBase64ToImage
    {
        public static Image Base64ToImage(this string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                Image image = Image.FromStream(ms);
                return image;
            }
        }
    }
}
