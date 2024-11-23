using Microsoft.EntityFrameworkCore;
using corvus_backend.Models;

namespace corvus_backend

{
    public class CorvusDbContext(DbContextOptions<CorvusDbContext> options) : DbContext(options)
    {
        public required DbSet<Coin> Coin { get; set; }
        public required DbSet<CoinCategory> CoinCategory { get; set; }
        public required DbSet<CoinCategoryRelation> CoinCategoryRelation { get; set; }
        public required DbSet<Platform> Platform { get; set; }
        public required DbSet<CoinPlatformRelation> CoinPlatformRelation { get; set; }
        public required DbSet<Image> Image { get; set; }
        public required DbSet<CoinImageRelation> CoinImageRelation { get; set; }
        public required DbSet<ContractAddress> ContractAddresse { get; set; }
        public required DbSet<CoinContractAddressRelation> CoinContractAddressRelation { get; set; }
        public required DbSet<Link> Link { get; set; }
        public required DbSet<CoinLinkRelation> CoinLinkRelation { get; set; }
        public required DbSet<HistoricalData5Min> HistoricalData5Min { get; set; }
        public required DbSet<HistoricalData15Min> HistoricalData15Min { get; set; }
        public required DbSet<HistoricalData1H> HistoricalData1H { get; set; }
        public required DbSet<HistoricalData1D> HistoricalData1D { get; set; }
        public required DbSet<User> User { get; set; }
        public required DbSet<UserCoinWatchlist> UserCoinWatchlist { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply unique index on str_id
            modelBuilder.Entity<Coin>()
                .HasIndex(c => c.StrId)
                .IsUnique();
        }

        public override int SaveChanges()
        {
            UpdateTimestamps();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateTimestamps();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateTimestamps()
        {
            var entries = ChangeTracker.Entries<BaseEntity>();
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                }
            }
        }
    }
}