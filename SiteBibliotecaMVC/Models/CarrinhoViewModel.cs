using System.Collections.Generic;

namespace SiteBibliotecaMVC.Models
{
    public class CarrinhoViewModel
    {
        public IEnumerable<LivroViewModel> Livros { get; set; }

        public UsuarioViewModel Usuario { get; set; }

        public CarrinhoViewModel()
        {
            Livros = new List<LivroViewModel>();
        }
    }
}