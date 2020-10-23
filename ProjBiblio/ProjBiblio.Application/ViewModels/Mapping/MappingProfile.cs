using AutoMapper;
using ProjBiblio.Domain.Entities;

namespace ProjBiblio.Application.ViewModels.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Autor, AutorViewModel>().ReverseMap();
        }
    }
}