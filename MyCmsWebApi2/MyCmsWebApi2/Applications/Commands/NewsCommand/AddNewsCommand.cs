﻿using MediatR;

namespace MyCmsWebApi2.Applications.Commands.NewsCommand
{
    public class AddNewsCommand: IRequest<int>
    {
        public int NewsGroupId { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Text { get; set; }
        public bool ShowInSlider { get; set; }
        public string Tags { get; set; }
    }
}
