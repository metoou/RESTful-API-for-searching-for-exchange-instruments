using Microsoft.EntityFrameworkCore;
using TestTask.Entities;

namespace TestTask.Sql
{
    public class DatabaseContext : DbContext
    {
        public DbSet<EmitentEntity> Emitents { get; set; }
        public DbSet<ExchangeEntity> Exchanges { get; set; }
        public DbSet<StockExchangeTradedAssetEntity> StockExchangeTradedAssets { get; set; }
        public DbSet<BondExchangeTradedAssetEntity> BondExchangeTradedAssets { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}