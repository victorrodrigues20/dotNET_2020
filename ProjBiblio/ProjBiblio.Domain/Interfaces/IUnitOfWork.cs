using ProjBiblio.Domain.Interfaces;

namespace ProjBiblio.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IAutorRepository AutorRepository { get; }

        ILivroRepository LivroRepository { get; }

        ICarrinhoRepository CarrinhoRepository { get; }

        IUsuarioRepository UsuarioRepository { get; }

        IEmprestimoRepository EmprestimoRepository { get; }

         void Commit();
    }
}