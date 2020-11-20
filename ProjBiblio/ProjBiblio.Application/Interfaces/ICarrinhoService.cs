using System.Collections.Generic;
using ProjBiblio.Application.InputModels;
using ProjBiblio.Application.ViewModels;

namespace ProjBiblio.Application.Interfaces
{
    public interface ICarrinhoService
    {
        CarrinhoListViewModel GetPorSession(string sessionId);

        CarrinhoViewModel Post(CarrinhoInputModel autor);

        CarrinhoViewModel Delete(int id);
    }
}