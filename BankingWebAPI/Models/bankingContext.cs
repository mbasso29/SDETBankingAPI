using Microsoft.EntityFrameworkCore;

namespace BankingWebAPI.Models
{
    public class bankingContext : DbContext
    {
        public bankingContext(DbContextOptions<bankingContext> options)
            : base(options)
        {
        }

        public DbSet<bankingModel> bankingModels { get; set; } = null!;
    }
}
