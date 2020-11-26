using System.Collections.Generic;
using ProjBiblio.Domain.Entities;

namespace ProjBiblio.Application.ViewModels
{
    public class AutorListViewModel
    {
        public IEnumerable<AutorViewModel> Autores { get; set; }
    }
}