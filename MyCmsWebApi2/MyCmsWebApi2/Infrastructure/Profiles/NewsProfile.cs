﻿using AutoMapper;
using MyCmsWebApi2.Applications.Commands.NewsCommand;
using MyCmsWebApi2.Domain.Entities;
using MyCmsWebApi2.Presentations.Dtos.NewsDto;
using MyCmsWebApi2.Presentations.Dtos.NewsDto.Admin;
using MyCmsWebApi2.Presentations.Dtos.NewsDto.Users;

namespace MyCmsWebApi2.Infrastructure.Profiles
{
    public class NewsProfile : Profile
    {
        public NewsProfile()
        {
            CreateMap<News, AdminAddNewsDto>();
            CreateMap<News, AdminNewsDto>()
                .ForMember(x => x.Images, opt =>
                opt.MapFrom(src => src.Images.Select(x => "/api/admin/Images/" + x.Id.ToString())));
            CreateMap<News, UserNewsDto>()
                .ForMember(x => x.Images, opt =>
                opt.MapFrom(src => src.Images.Select(x => "/api/admin/Images/" + x.Id.ToString())));

            CreateMap<AdminEditNewsDto, News>();
            CreateMap<News, AdminEditNewsDto>();
            CreateMap<AdminAddNewsDto, News>();

            CreateMap<News,TopNewsDto>();
            CreateMap<TopNewsDto,News >();

            CreateMap<AdminAddNewsDto, AddNewsCommand>();
            CreateMap<AddNewsCommand,AdminAddNewsDto>();

            CreateMap<News, AddNewsCommand>();
            CreateMap<AddNewsCommand, News>();

            CreateMap<AdminEditNewsDto,EditNewsCommand>();
            CreateMap<EditNewsCommand,AdminEditNewsDto>();


        }
    }
}
