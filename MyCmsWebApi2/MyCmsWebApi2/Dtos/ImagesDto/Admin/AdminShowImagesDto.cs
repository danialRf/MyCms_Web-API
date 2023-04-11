using MyCmsWebApi2.BussinessLayer.Convertor;
using System.Buffers.Text;
using System.Text.Json.Serialization;

namespace MyCmsWebApi2.Dtos.ImagesDto
{
    public class AdminShowImagesDto
    {
        public Guid Id { get; set; }
        public string ImageName { get; set; } = string.Empty;
       
        public DateTime CreateDate { get; set; } = DateTime.Now;

        private IFormFile _base64;

        public string Base64
        {
            get => null; // We don't need a getter for this property
            set
            {
                // Convert the base64 string to an image and store it in _base64
                _base64 = (IFormFile)(value != null ? value.Base64ToImage() : null);
            }
        }

        // This property is used to get the actual image from _base64
        [JsonIgnore]
        public Stream ImageStream => _base64?.OpenReadStream();

        public int? NewsId { get; set; }  

        public int? NewsGroupId { get; set; }


    }
}



