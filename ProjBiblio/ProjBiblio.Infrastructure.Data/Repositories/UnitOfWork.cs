using ProjBiblio.Domain.Interfaces;
using ProjBiblio.Infrastructure.Data.Context;

namespace ProjBiblio.Infrastructure.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private AutorRepository _autorRepo; 

        private LivroRepository _livroRepo;

        private CarrinhoRepository _carrinhoRepo;

        private UsuarioRepository _usuarioRepo;

        private EmprestimoRepository _emprestimoRepo;
        
        private BibliotecaDbContext _context;

        public IAutorRepository AutorRepository
        {
            get { 
                return _autorRepo = _autorRepo ?? new AutorRepository(_context);
            }
        }

        public ILivroRepository LivroRepository
        {
            get { 
                return _livroRepo = _livroRepo ?? new LivroRepository(_context);
            }
        }

        public ICarrinhoRepository CarrinhoRepository
        {
            get { 
                return _carrinhoRepo = _carrinhoRepo ?? new CarrinhoRepository(_context);
            }
        }

        public IUsuarioRepository UsuarioRepository
        {
            get { 
                return _usuarioRepo = _usuarioRepo ?? new UsuarioRepository(_context);
            }
        }

        public IEmprestimoRepository EmprestimoRepository
        {
            get { 
                return _emprestimoRepo = _emprestimoRepo ?? new EmprestimoRepository(_context);
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