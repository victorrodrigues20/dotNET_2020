using AutoMapper;
using ProjBiblio.Domain.Entities;

namespace ProjBiblio.Application.ViewModels.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Autor, AutorViewModel>()
                .ForMember(dest => dest.Id, 
                           opt => opt.MapFrom(src => src.AutorID))
                .ReverseMap();

            CreateMap<Livro, LivroViewModel>()
                .ForMember(dest => dest.Id, 
                           opt => opt.MapFrom(src => src.LivroID))
                .ForMember(dest => dest.Autores,
                            opt => opt.MapFrom(src => src.LivAutor))   
                .ReverseMap();

            CreateMap<Carrinho, CarrinhoViewModel>()
                .ForMember(dest => dest.Id, 
                           opt => opt.MapFrom(src => src.CarrinhoID))
                .ForMember(dest => dest.NomeLivro,
                           opt => 
                            {
                                opt.PreCondition(src => src.Livro != null);
                                opt.MapFrom(src => src.Livro.Titulo);
                            })
                .ReverseMap();
        }
    }
}