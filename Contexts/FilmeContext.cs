
using Microsoft.EntityFrameworkCore;
using rentflix.service.Models;

namespace rentflix.service.Contexts
{
    public class FilmeContext : DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> options) : base(options)
        {
        }

        public DbSet<Filme> Filmes { get; set; }
    }

}