using ProjBiblio.Domain.Entities;
using ProjBiblio.Domain.Interfaces;
using ProjBiblio.Infrastructure.Data.Context;

namespace ProjBiblio.Infrastructure.Data.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(BibliotecaDbContext context) : base(context)
        {
            
        }
    }
}