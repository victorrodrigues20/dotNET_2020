using System.Collections.Generic;

namespace SiteBibliotecaMVC.Models
{
    public class LivroListViewModel
    {
        public IEnumerable<LivroViewModel> Livros { get; set; }
    }
}