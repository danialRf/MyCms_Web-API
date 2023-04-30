using AutoMapper;
using MyCmsWebApi2.Domain.Entities;
using MyCmsWebApi2.Presentations.Dtos.ImagesDto.Admin;
using MyCmsWebApi2.Presentations.Dtos.ImagesDto;
using MyCmsWebApi2.Applications.Commands.ImagesCommand;

namespace MyCmsWebApi2.Infrastructure.Profiles
{
    public class ImageProfile : Profile
    {
        public ImageProfile()
        {
            CreateMap<EditImageCommand, AdminEditImageDto > ();
            CreateMap<AdminEditImageDto, EditImageCommand>();
            CreateMap<AdminAddImageDto, AddImageCommand>();
        }
    }
}
