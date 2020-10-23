using ProjBiblio.Application.ViewModels;

namespace ProjBiblio.Application.Interfaces
{
    public interface IAutorService
    {
        AutorListViewModel Get();

        AutorViewModel Get(int id);
    }
}