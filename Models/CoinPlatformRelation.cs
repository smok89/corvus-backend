using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace corvus_backend.Models
{
    [Table("coin_platform_relation")]
    public class CoinPlatformRelation
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("coin_id")]
        public int CoinId { get; set; }

        [Column("platform_id")]
        public int PlatformId { get; set; }

        [ForeignKey("CoinId")]
        public Coin Coin { get; set; }

        [ForeignKey("PlatformId")]
        public Platform Platform { get; set; }
    }
}