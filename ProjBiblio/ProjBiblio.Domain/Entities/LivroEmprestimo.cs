namespace ProjBiblio.Domain.Entities
{
    public class LivroEmprestimo
    {
        public int LivroID { get; set; }
        public Livro Livro { get; set; }

        public int EmprestimoID { get; set; }
        public Emprestimo Emprestimo { get; set; }
    }
}