using Microsoft.EntityFrameworkCore;
using ProjBiblio.Domain.Entities;

namespace ProjBiblio.Infrastructure.Data.Context
{
    public class BibliotecaDbContext : DbContext
    {
        public BibliotecaDbContext(DbContextOptions<BibliotecaDbContext> options) : base(options)
        {

        }

        public DbSet<Autor> Autor { get; set; }   
    }
}