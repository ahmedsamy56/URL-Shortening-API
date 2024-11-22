using AutoMapper;
using URL_Shortening.Models;

namespace URL_Shortening.DTOs.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ShortUrl, UrlDto>().ReverseMap();

            CreateMap<ShortUrl, UrlStatsDto>().ReverseMap();
        }
    }
}
