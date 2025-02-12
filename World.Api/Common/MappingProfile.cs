using AutoMapper;
using World.Api.DTO.Country;
using World.Api.DTO.State;
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
            CreateMap<State, CreateStateDto>().ReverseMap();
            CreateMap<State, GetAllStateDto>().ReverseMap();
            CreateMap<State, GetByIdStateDto>().ReverseMap();
            CreateMap<State, UpdateStateDto>().ReverseMap();

        }
    }
}
