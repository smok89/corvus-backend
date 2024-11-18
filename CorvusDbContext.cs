using Microsoft.EntityFrameworkCore;
using corvus_backend.Models;

namespace corvus_backend

{
    public class CorvusDbContext : DbContext
    {
        public DbSet<Coin> Coin { get; set; }
        public DbSet<CoinCategory> CoinCategory { get; set; }
        public DbSet<CoinCategoryRelation> CoinCategoryRelation { get; set; }
        public DbSet<Platform> Platform { get; set; }
        public DbSet<CoinPlatformRelation> CoinPlatformRelation { get; set; }
        public DbSet<Image> Image { get; set; }
        public DbSet<CoinImageRelation> CoinImageRelation { get; set; }
        public DbSet<ContractAddress> ContractAddresse { get; set; }
        public DbSet<CoinContractAddressRelation> CoinContractAddressRelation { get; set; }
        public DbSet<Link> Link { get; set; }
        public DbSet<CoinLinkRelation> CoinLinkRelation { get; set; }
        public DbSet<HistoricalData5Min> HistoricalData5Min { get; set; }
        public DbSet<HistoricalData15Min> HistoricalData15Min { get; set; }
        public DbSet<HistoricalData1H> HistoricalData1H { get; set; }
        public DbSet<HistoricalData1D> HistoricalData1D { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserCoinWatchlist> UserCoinWatchlist { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}