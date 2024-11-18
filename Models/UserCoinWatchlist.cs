using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace corvus_backend.Models
{
    [Table("user_coin_watchlist")]
    public class UserCoinWatchlist
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("coin_id")]
        public int CoinId { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("CoinId")]
        public Coin Coin { get; set; }
    }
}