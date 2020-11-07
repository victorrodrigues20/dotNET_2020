using ProjBiblio.Domain.Interfaces;
using ProjBiblio.Infrastructure.Data.Context;

namespace ProjBiblio.Infrastructure.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private AutorRepository _autorRepo; 

        private BibliotecaDbContext _context;

        public IAutorRepository AutorRepository
        {
            get { 
                return _autorRepo = _autorRepo ?? new AutorRepository(_context);
            }
        }

        public UnitOfWork(BibliotecaDbContext contexto)
        {
            _context = contexto;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}