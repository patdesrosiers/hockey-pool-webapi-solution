using Microsoft.EntityFrameworkCore;

namespace HockeyPoolWebApi.Models
{
    public class PoolersContext : DbContext    
    {
        public DbSet<Pooler> Poolers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=hockey-pool.db");
        }
    }
}