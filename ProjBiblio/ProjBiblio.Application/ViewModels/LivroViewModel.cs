using System.Collections.Generic;
using ProjBiblio.Application.DTOs;

namespace ProjBiblio.Application.ViewModels
{
    public class LivroViewModel
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public int? Quantidade { get; set; }

        public string Foto { get; set; }

        public IList<AutorSelectListDto> Autores { get; set; }
    }
}