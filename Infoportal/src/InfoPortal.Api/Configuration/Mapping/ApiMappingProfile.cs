using AutoMapper;
using InfoPortal.Api.Models.Request;
using InfoPortal.Api.Models.Response;
using InfoPortal.Application.Contracts.Logic.Services.News.Models;
using InfoPortal.Application.Contracts.Logic.Services.Tags.Models;


namespace InfoPortal.Host.Configuration.Mapping
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<CreateNewsModel, CreateNewsDto>().ReverseMap();
            CreateMap<CreateTagModel, CreateTagDto>().ReverseMap();
            CreateMap<UpdateNewsModel, UpdateNewsDto>().ReverseMap();
            CreateMap<UpdateTagModel, UpdateTagDto>().ReverseMap();
            CreateMap<NewsModel, NewsDto>().ReverseMap();
            CreateMap<TagModel, TagDto>().ReverseMap();
        }
    }
}
