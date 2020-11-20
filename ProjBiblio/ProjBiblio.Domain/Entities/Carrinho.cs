using System;

namespace ProjBiblio.Domain.Entities 
{
    public class Carrinho 
    {
        public int CarrinhoID { get; set; }

        public DateTime Data { get; set; }

        public int? EmprestimoID { get; set; }

        // Normalizar posteriormente em uma tabela CarrinhoItem
        // Fiz desse jeito só para facilitar a criação dos serviços
        public int LivroID { get; set; }

        public virtual Livro Livro { get; set; }

        public int Quantidade { get; set; }
    }
}