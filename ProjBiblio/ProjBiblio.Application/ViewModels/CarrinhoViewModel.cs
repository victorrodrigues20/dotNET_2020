using System;

namespace ProjBiblio.Application.ViewModels
{
    public class CarrinhoViewModel
    {
        public long Id { get; set; }
        public int? EmprestimoID { get; set; }

        public string SessionUserID { get; set; }

        // Normalizar posteriormente em uma tabela CarrinhoItem
        // Fiz desse jeito só para facilitar a criação dos serviços
        public int LivroID { get; set; }

        public string NomeLivro { get; set; }

        public int Quantidade { get; set; }
    }
}