using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjBiblio.Domain.Entities;
using ProjBiblio.Infrastructure.Data.Context.Config;

namespace ProjBiblio.Infrastructure.Data.Context
{
    public class BibliotecaDbContext : IdentityDbContext
    {
        public BibliotecaDbContext(DbContextOptions<BibliotecaDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // modelBuilder.ApplyConfiguration(new AutorConfiguration());

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            // // modelBuilder.Entity<Autor>()
            // //     .Property(p => p.Nome)
            // //     .IsRequired();
        }

        public DbSet<Autor> Autor { get; set; }

        public DbSet<Livro> Livro { get; set; }  

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Emprestimo> Emprestimo { get; set; }

        public DbSet<LivroAutor> LivroAutor { get; set; }

        public DbSet<LivroEmprestimo> LivroEmprestimo { get; set; }

        public DbSet<Carrinho> Carrinho { get; set; }
    }
}