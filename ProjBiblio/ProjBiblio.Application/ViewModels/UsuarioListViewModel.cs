using System.Collections.Generic;
using ProjBiblio.Domain.Entities;

namespace ProjBiblio.Application.ViewModels
{
    public class UsuarioListViewModel
    {
        public IEnumerable<UsuarioViewModel> Usuarios { get; set; }
    }
}