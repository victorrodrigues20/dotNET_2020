using System.Collections.Generic;

namespace ProjBiblio.Application.ViewModels
{
    public class EmprestimoListViewModel
    {
        public IEnumerable<EmprestimoViewModel> Emprestimos { get; set; }
    }
}