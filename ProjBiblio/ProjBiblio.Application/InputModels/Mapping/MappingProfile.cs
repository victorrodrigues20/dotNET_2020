using AutoMapper;
using ProjBiblio.Domain.Entities;

namespace ProjBiblio.Application.InputModels.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Autor, AutorInputModel>()
                .ForMember(dest => dest.Id, 
                           opt => opt.MapFrom(src => src.AutorID))
                .ReverseMap();

            CreateMap<Livro, LivroInputModel>()
                .ForMember(dest => dest.Id, 
                           opt => opt.MapFrom(src => src.LivroID))
                .ForMember(dest => dest.Autores,
                            opt => opt.MapFrom(src => src.LivAutor))   
                .ReverseMap();

            CreateMap<Carrinho, CarrinhoInputModel>()
                .ForMember(dest => dest.Id, 
                            opt => opt.MapFrom(src => src.CarrinhoID))
                .ReverseMap();

            CreateMap<Usuario, UsuarioInputModel>()
                .ForMember(dest => dest.Id, 
                           opt => opt.MapFrom(src => src.UsuarioID))
                .ReverseMap();
        }
    }
}