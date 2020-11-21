using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProjBiblio.Domain.Entities;
using ProjBiblio.Domain.Interfaces;
using ProjBiblio.Infrastructure.Data.Context;

namespace ProjBiblio.Infrastructure.Data.Repositories
{
    public class EmprestimoRepository : Repository<Emprestimo>, IEmprestimoRepository
    {
        public EmprestimoRepository(BibliotecaDbContext context) : base(context)
        {
        }

        public IEnumerable<Emprestimo> GetEmprestimoPorUsuario(int usuarioId)
        {
            return _context.Emprestimo
                .Where(l => l.UsuarioID == usuarioId);
        }

        public Emprestimo GetEmprestimoInclude(int emprestimoId)
        {
            return (_context.Emprestimo
                .Include(e => e.LivEmprestimo)
                .ThenInclude(e => e.Livro)
                .ThenInclude(e => e.LivAutor)
                .ThenInclude(e => e.Autor)
                .Where(l => l.EmprestimoID == emprestimoId))
                .SingleOrDefault();
        }
    }
}