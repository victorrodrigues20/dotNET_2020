using ProjBiblio.Application.InputModels;
using ProjBiblio.Application.ViewModels;

namespace ProjBiblio.Application.Interfaces
{
    public interface IUsuarioService
    {
        UsuarioListViewModel Get();

        UsuarioViewModel Post(UsuarioInputModel autor);
    }
}