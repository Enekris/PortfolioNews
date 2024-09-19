using AutoMapper;
using InfoPortal.Application.Contracts.Logic.Services.News.Models;
using InfoPortal.Application.Contracts.Logic.Services.Tags.Models;
using InfoPortal.Domains.Entities;


namespace InfoPortal.Application
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<NewsDb, NewsDto>().ReverseMap();
            CreateMap<TagDb, TagDto>().ReverseMap();
        }
    }
}
