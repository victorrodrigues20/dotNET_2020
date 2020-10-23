using ProjBiblio.Application.ViewModels;

namespace ProjBiblio.Application.Interfaces
{
    public interface IAutorService
    {
        AutorListViewModel Get();

        AutorViewModel Get(int id);

        AutorViewModel Post(AutorViewModel autor);

        AutorViewModel Put(int id, AutorViewModel autor);

        AutorViewModel Delete(int id);
    }
}