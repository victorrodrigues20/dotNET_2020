using System.Collections.Generic;

namespace ProjBiblio.Application.ViewModels
{
    public class CarrinhoListViewModel
    {
        public IEnumerable<CarrinhoViewModel> Items { get; set; }
    }
}