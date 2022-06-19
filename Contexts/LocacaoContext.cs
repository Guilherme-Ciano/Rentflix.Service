
using Microsoft.EntityFrameworkCore;
using rentflix.service.Models;

namespace rentflix.service.Contexts
{
    public class LocacaoContext : DbContext
    {
        public LocacaoContext(DbContextOptions<LocacaoContext> options) : base(options)
        {
        }

        public DbSet<Locacao> Locacoes { get; set; }
    }

}