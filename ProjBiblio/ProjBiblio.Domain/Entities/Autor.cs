using System.Collections.Generic;

namespace ProjBiblio.Domain.Entities
{
    public class Autor
    {
        public int AutorID { get; set; }

        public string Nome { get; set; }

        public ICollection<LivroAutor> LivAutor { get; set; }
    }
}