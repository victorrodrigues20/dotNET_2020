using ProjBiblio.Domain.Interfaces;

namespace ProjBiblio.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IAutorRepository AutorRepository { get; }

         void Commit();
    }
}