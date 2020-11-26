using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProjBiblio.Domain.Entities;
using ProjBiblio.Domain.Interfaces;
using ProjBiblio.Infrastructure.Data.Context;

namespace ProjBiblio.Infrastructure.Data.Repositories {
    public class CarrinhoRepository : Repository<Carrinho>, ICarrinhoRepository {
        public CarrinhoRepository (BibliotecaDbContext context) : base (context) { }

        public IEnumerable<Carrinho> GetCarrinhoPorSessionId (string idSession) {
            return _context.Carrinho.AsNoTracking ()
                .Include (c => c.Livro)
                .Where (c => c.SessionUserID == idSession);
        }
    }
}