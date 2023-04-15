using AutoMapper;
using MyCmsWebApi2.Applications.Commands.Images;
using MyCmsWebApi2.Domain.Entities;
using MyCmsWebApi2.Presentations.Dtos.ImagesDto.Admin;
using MyCmsWebApi2.Presentations.Dtos.ImagesDto.User;

namespace MyCmsWebApi2.Infrastructure.Profiles
{
    public class ImageProfile : Profile
    {
        public ImageProfile()
        {
            CreateMap<Image, AdminShowImagesDto>();
            CreateMap<AddImageDto, AddImageCommand>();
        }
    }
}
