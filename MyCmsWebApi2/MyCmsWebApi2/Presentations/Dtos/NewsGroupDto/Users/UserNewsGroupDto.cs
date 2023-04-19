using MyCmsWebApi2.Domain.Entities;

namespace MyCmsWebApi2.Presentations.Dtos.NewsGroupDto.Users
{
    public class UserNewsGroupDto
    {
        internal int Id { get; set; }
        public string GroupTitle { get; set; } = string.Empty;
       
    }
}
