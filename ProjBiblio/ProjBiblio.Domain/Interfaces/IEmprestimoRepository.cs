using System.Collections.Generic;
using ProjBiblio.Domain.Entities;

namespace ProjBiblio.Domain.Interfaces
{
    public interface IEmprestimoRepository  : IRepository<Emprestimo>
    {
        IEnumerable<Emprestimo> GetEmprestimoPorUsuario(int usuarioId);

        Emprestimo GetEmprestimoInclude(int emprestimoId);
    }
}