﻿namespace MyCmsWebApi2.Dtos
{
    public class EditNewsDto
    {
        public int? Id { get; set; }
        public int NewsGroupId { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Text { get; set; }
        public bool ShowInSlider { get; set; }
        public string Tags { get; set; }
    }
}
