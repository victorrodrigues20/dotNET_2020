using System.Collections.Generic;

namespace ProjBiblio.Application.DTOs
{
    public class AutorSelectListDto
    {
        public int AutorID { get; set; }

        public string Nome { get; set; }

        public bool Selecionado { get; set; }
    }
}