using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProjBiblio.Domain.Entities;
using ProjBiblio.Domain.Interfaces;
using ProjBiblio.Infrastructure.Data.Context;

namespace ProjBiblio.Infrastructure.Data.Repositories
{
    public class AutorRepository : Repository<Autor>, IAutorRepository
    {
        public AutorRepository(BibliotecaDbContext context) : base(context)
        {
            
        }

        public IEnumerable<Autor> GetAutoresContemNome(string nome)
        {
            return _context.Set<Autor>()
                .Where(a => a.Nome.Contains(nome));
        }

        public IEnumerable<Autor> GetAutoresPorLivro(int idLivro)
        {
            return _context.Autor.AsNoTracking()
                .Include(l => l.LivAutor)
                .Where(l => l.LivAutor.Any(la => la.LivroID == idLivro));
        }
    }
}