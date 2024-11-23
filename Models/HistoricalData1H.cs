using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace corvus_backend.Models
{
    [Table("historical_data_1h")]
    public class HistoricalData1H : BaseEntity
    {
        [Column("coin_id")]
        public int CoinId { get; set; }

        [ForeignKey("CoinId")]
        public Coin? Coin { get; set; }

        [Column("timestamp")]
        public DateTime Timestamp { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("market_cap")]
        public long MarketCap { get; set; }

        [Column("volume_24h")]
        public decimal Volume24h { get; set; }

        [Column("high")]
        public decimal High { get; set; }

        [Column("low")]
        public decimal Low { get; set; }
    }
}