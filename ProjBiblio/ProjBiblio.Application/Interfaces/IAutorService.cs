using System.Collections.Generic;
using System.Threading.Tasks;
using ProjBiblio.Application.DTOs;
using ProjBiblio.Application.InputModels;
using ProjBiblio.Application.ViewModels;

namespace ProjBiblio.Application.Interfaces
{
    public interface IAutorService
    {
        AutorListViewModel Get();

        AutorViewModel Get(int id);

        AutorViewModel Post(AutorInputModel autor);

        AutorViewModel Put(int id, AutorInputModel autor);

        AutorViewModel Delete(int id);

        IList<AutorSelectListDto> ListagemAutoresPorLivro(int idLivro);
    }
}