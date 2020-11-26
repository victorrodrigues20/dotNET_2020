using ProjBiblio.Application.InputModels;
using ProjBiblio.Application.ViewModels;

namespace ProjBiblio.Application.Interfaces
{
    public interface IEmprestimoService
    {
        EmprestimoListViewModel GetPorUsuario(int usuarioId);

        EmprestimoViewModel GetEmprestimoDetalhes(int emprestimoId);

        EmprestimoViewModel CriarEmprestimo(EmprestimoInputModel emprestimo);

        EmprestimoViewModel DevolverLivros(int emprestimoId);
    }
}