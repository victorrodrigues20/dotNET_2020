using System.Collections.Generic;
using ProjBiblio.Domain.Entities;

namespace ProjBiblio.Application.ViewModels
{
    public class AutorListViewModel
    {
        public IEnumerable<Autor> Autores { get; set; }
    }
}