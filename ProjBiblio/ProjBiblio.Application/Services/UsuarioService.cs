using ProjBiblio.Application.Interfaces;
using ProjBiblio.Application.ViewModels;
using ProjBiblio.Domain.Interfaces;

namespace ProjBiblio.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        public IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            this._usuarioRepository = usuarioRepository;
        }

        public UsuarioListViewModel Get()
        {
            return new UsuarioListViewModel()
            {
                Usuarios = this._usuarioRepository.Get()
            };
        }
    }
}