using AutoMapper;
using MyCmsWebApi2.Applications.Commands;
using MyCmsWebApi2.DataLayer.Model;
using MyCmsWebApi2.Presentations.Dtos.ImagesDto.Admin;
using MyCmsWebApi2.Presentations.Dtos.ImagesDto.User;

namespace MyCmsWebApi2.Infrastructure.Profiles
{
    public class ImageProfile : Profile
    {
        public ImageProfile()
        {
            CreateMap<Images, AdminShowImagesDto>();
            CreateMap<AddImageDto, AddImageCommand>();
        }
    }
}
