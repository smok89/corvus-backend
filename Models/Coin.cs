using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace corvus_backend.Models
{
    [Table("coin")]
    public class Coin : BaseEntity
    {
        [Column("str_id")]
        [MaxLength(100)]
        public string? StrId { get; set; }

        [Column("symbol")]
        [MaxLength(10)]
        public string? Symbol { get; set; }

        [Column("name")]
        [MaxLength(100)]
        public string? Name { get; set; }

        [Column("web_slug")]
        [MaxLength(100)]
        public string? WebSlug { get; set; }

        [Column("market_cap")]
        public long MarketCap { get; set; }

        [Column("market_cap_rank")]
        public int MarketCapRank { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("volume_24h")]
        public decimal Volume24h { get; set; }

        [Column("fully_diluted_valuation")]
        public long FullyDilutedValuation { get; set; }

        [Column("circulating_supply")]
        public decimal CirculatingSupply { get; set; }

        [Column("total_supply")]
        public decimal TotalSupply { get; set; }

        [Column("max_supply")]
        public decimal MaxSupply { get; set; }
    }
}