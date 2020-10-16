using ProjBiblio.Application.ViewModels;

namespace ProjBiblio.Application.Interfaces
{
    public interface ILivroService
    {
        LivroListViewModel Get();
    }
}