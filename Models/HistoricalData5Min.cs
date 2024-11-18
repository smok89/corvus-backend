using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace corvus_backend.Models
{
    [Table("historical_data_5min")]
    public class HistoricalData5Min
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("coin_id")]
        public int CoinId { get; set; }

        [Column("timestamp")]
        public DateTime Timestamp { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("market_cap")]
        public long MarketCap { get; set; }

        [Column("volume_24h")]
        public decimal Volume24h { get; set; }

        [ForeignKey("CoinId")]
        public Coin Coin { get; set; }
    }
}