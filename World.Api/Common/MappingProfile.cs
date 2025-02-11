using AutoMapper;
using World.Api.DTO;
using World.Api.Models;

namespace World.Api.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Source,Destination
            CreateMap<Country,CreateCountryDto>().ReverseMap();
            CreateMap<Country, GetAllCountryDto>().ReverseMap();
            CreateMap<Country, GetByIdCountryDto>().ReverseMap();
            CreateMap<Country, UpdateCountryDto>().ReverseMap();

        }
    }
}
