using System.Collections.Generic;
using ProjBiblio.Domain.Entities;

namespace ProjBiblio.Domain.Interfaces
{
    public interface ICarrinhoRepository  : IRepository<Carrinho>
    {
         IEnumerable<Carrinho> GetCarrinhoPorSessionId(string idSession);
    }
}