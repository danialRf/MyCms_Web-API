﻿namespace MyCmsWebApi2.Dtos
{
    public class GetCommentDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Text { get; set; }

    }
}