using System.Collections.Generic;

namespace ProjBiblio.Application.ViewModels
{
    public class EmprestimoViewModel
    {
        public int Id { get; set; }

        public int UsuarioID { get; set; }

        public string DataInicio { get; set; }

        public string DataFim { get; set; }

        public string DataDevolucao { get; set; }

        public ICollection<LivroViewModel> Livros { get; set; }

        public EmprestimoViewModel()
        {
            Livros = new List<LivroViewModel>();
        }
    }
}