﻿namespace MyCmsWebApi2.Presentations.Dtos.ImagesDto.Admin

{
    public class AdminAddImageDto
    {
        // public Guid Id { get; set; }
        public IFormFile ImageFile { get; set; }
        public int? NewsId { get; set; }
        public int? NewsGroupId { get; set; }

    }
}
