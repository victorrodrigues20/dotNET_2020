using System.Collections.Generic;

namespace SiteBibliotecaMVC.Models
{
    public class EmprestimoInputModel
    {
        public int Id { get; set; }

        public int UsuarioID { get; set; }

        public string SessionUserId { get; set; }
    }
}