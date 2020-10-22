using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ProjBiblio.Domain.Entities;

namespace ProjBiblio.Domain.Interfaces
{
    public interface ILivroRepository  : IRepository<Livro>
    {
        IEnumerable<Livro> GetLivrosSemEstoque();
        IEnumerable<Livro> GetLivrosContemTitulo(string titulo);
        IEnumerable<Livro> GetLivrosPorAutor(int autorID);
    }
}