using System.Collections.Generic;

namespace ProjBiblio.Domain.Entities
{
    public class Emprestimo
    {
        public int EmprestimoID { get; set; }

        public int UsuarioID { get; set; }

        public virtual Usuario Usuario { get; set; }

        public string DataInicio { get; set; }

        public string DataFim { get; set; }

        public string DataDevolucao { get; set; }

        public ICollection<LivroEmprestimo> LivEmprestimo { get; set; }
    }
}