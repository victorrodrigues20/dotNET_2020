namespace ProjBiblio.Domain.Entities
{
    public class Livro
    {
        public int LivroID { get; set; }

        public string Titulo { get; set; }

        public int? Quantidade { get; set; }

        public string Foto { get; set; }
    }
}