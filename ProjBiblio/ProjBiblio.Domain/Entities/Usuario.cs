using System.Collections.Generic;

namespace ProjBiblio.Domain.Entities
{
    public class Usuario
    {
        public int UsuarioID { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}