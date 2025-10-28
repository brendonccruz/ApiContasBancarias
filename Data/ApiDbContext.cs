using Microsoft.EntityFrameworkCore;

namespace MinhaNovaApi.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

        public DbSet<ContaEmpresarial> Contas { get; set; }
    }
}