using System.Collections.Generic;
using ProjBiblio.Domain.Entities;

namespace ProjBiblio.Domain.Interfaces
{
    public interface IAutorRepository : IRepository<Autor>
    {
        IEnumerable<Autor> GetAutoresContemNome(string nome);
    }
}