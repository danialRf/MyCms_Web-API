using AutoMapper;
using MyCmsWebApi2.DataLayer.Model;
using MyCmsWebApi2.Dtos.ImagesDto;
using MyCmsWebApi2.Dtos.NewsDto.Admin;
using MyCmsWebApi2.Dtos.NewsGroupDto.Admin;

namespace MyCmsWebApi2.Profiles
{
    public class ImageProfile : Profile
    {
        public ImageProfile()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AdminShowImagesDto, Images>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.ImageName, opt => opt.MapFrom(src => src.ImageName))
                    .ForMember(dest => dest.Base64, opt => opt.MapFrom(src => src.Base64));

            });


            IMapper mapper = config.CreateMapper();

            CreateMap<Images, AdminShowImagesDto>();

            CreateMap<AddImageDto,Images >();

        }
    }
}
