using ApiRestNET.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiRestNET.Contexto
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Coche> coches { get; set; }
    }
}
