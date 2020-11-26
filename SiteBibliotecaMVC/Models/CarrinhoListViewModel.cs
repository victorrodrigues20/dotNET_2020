using System.Collections.Generic;

namespace SiteBibliotecaMVC.Models
{
    public class CarrinhoListViewModel
    {
        public IEnumerable<CarrinhoViewModel> Items { get; set; }
    }
}