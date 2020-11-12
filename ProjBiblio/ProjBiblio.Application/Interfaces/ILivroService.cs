using ProjBiblio.Application.InputModels;
using ProjBiblio.Application.ViewModels;

namespace ProjBiblio.Application.Interfaces
{
    public interface ILivroService
    {
        LivroListViewModel Get();

        LivroViewModel Get(int id);

        LivroViewModel Post(LivroInputModel livro);

        LivroViewModel Put(int id, LivroInputModel livro);

        LivroViewModel Delete(int id);
    }
}