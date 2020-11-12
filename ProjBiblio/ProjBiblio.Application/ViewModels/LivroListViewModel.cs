using System.Collections.Generic;
using ProjBiblio.Domain.Entities;

namespace ProjBiblio.Application.ViewModels
{
    public class LivroListViewModel
    {
        public IEnumerable<LivroViewModel> Livros { get; set; }
    }
}