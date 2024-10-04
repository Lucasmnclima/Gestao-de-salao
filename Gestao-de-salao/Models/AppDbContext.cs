using Microsoft.EntityFrameworkCore;
namespace Gestao_de_salao.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) 
        {
        }
        public DbSet<Salao> Saloes { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
    }
}
