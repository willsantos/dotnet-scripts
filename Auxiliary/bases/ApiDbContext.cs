using Academy.DDD.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Academy.DDD.Infrastructure.Contexts
{
    public class ManutencaoContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ManutencaoContext> options) : base(options)
        { 
        }

        //public DbSet<Usuario> Usuarios { get; set; }
        
    }
}
