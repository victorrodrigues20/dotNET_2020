using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjBiblio.Domain.Entities;

namespace ProjBiblio.Infrastructure.Data.Context.Config
{
    public class LivroAutorConfiguration : IEntityTypeConfiguration<LivroAutor>
    {
        public void Configure(EntityTypeBuilder<LivroAutor> builder)
        {
            #region LivroAutor

            //a Gera Chave Primaria Composta
            builder.HasKey(bc => new { bc.AutorID, bc.LivroID });

            builder.HasOne(bc => bc.Autor)
                .WithMany(b => b.LivAutor)
                .HasForeignKey(bc => bc.AutorID);

            builder.HasOne(bc => bc.Livro)
                .WithMany(c => c.LivAutor)
                .HasForeignKey(bc => bc.LivroID);

            #endregion
        }
    }
}