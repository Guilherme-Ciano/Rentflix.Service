
using Microsoft.EntityFrameworkCore;
using rentflix.service.Models;

namespace rentflix.service.Contexts
{
    public class ClienteContext : DbContext
    {
        public ClienteContext(DbContextOptions<ClienteContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
    }

}