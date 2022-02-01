using AutoMapper;
using WebApi.Domain.Models;
using WebApi.Responses;

namespace WebApi.Mappers
{
    public class HeroProfile : Profile
    {
        public HeroProfile()
        {
            CreateMap<Hero, HeroResponse>()
                .ForMember(dest => dest.Comics, source => source.MapFrom(s => s.Comics.Name))
                .ReverseMap();
        }
    }
}
