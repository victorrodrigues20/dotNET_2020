using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjBiblio.Domain.Entities;

namespace ProjBiblio.Infrastructure.Data.Context.Config
{
    public class LivroConfiguration : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.Property(t => t.Titulo)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.Foto)
                .HasMaxLength(300);
        }
    }
}