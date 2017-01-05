using Plutus.Models;
using Microsoft.EntityFrameworkCore;

namespace Plutus.Data
{
    public class PlutusContext:DbContext
    {
        public PlutusContext(DbContextOptions<PlutusContext> options) : base(options)
        {
        }

        public DbSet<Website> Websites { get; set; }
        public DbSet<Card> Cards { get; set; }

        public DbSet<MonthlyData> MonthlyRecords { get; set; }

        public DbSet<DailyData> DailyRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Website>().ToTable("Website");
            modelBuilder.Entity<Card>().ToTable("Card");
            modelBuilder.Entity<MonthlyData>().ToTable("MonthlyData");
            modelBuilder.Entity<DailyData>().ToTable("DailyData");
        }
    }
}
