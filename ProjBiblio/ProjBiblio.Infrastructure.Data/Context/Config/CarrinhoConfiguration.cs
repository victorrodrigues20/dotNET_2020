using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjBiblio.Domain.Entities;

namespace ProjBiblio.Infrastructure.Data.Context.Config
{
    public class CarrinhoConfiguration : IEntityTypeConfiguration<Carrinho>
    {
        public void Configure(EntityTypeBuilder<Carrinho> builder)
        {
            // Gera Chave Primaria Composta
            builder.HasKey(c => c.CarrinhoID);
        }
    }
}