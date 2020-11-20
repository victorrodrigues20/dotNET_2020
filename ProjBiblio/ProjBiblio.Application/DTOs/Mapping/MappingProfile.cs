using AutoMapper;
using ProjBiblio.Application.DTOs;
using ProjBiblio.Domain.Entities;

namespace ProjBiblio.Application.DTOs.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LivroAutor, AutorSelectListDto>()
                .ForMember(dest => dest.AutorID, 
                            opt => opt.MapFrom(src => src.AutorID))
                .ReverseMap();
        }
    }
}