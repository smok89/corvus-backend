using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace corvus_backend.Models
{
    [Table("coin_category_relation")]
    public class CoinCategoryRelation : BaseEntity
    {
        [Column("coin_id")]
        public int CoinId { get; set; }

        [Column("category_id")]
        public int CategoryId { get; set; }

        [ForeignKey("CoinId")]
        public Coin? Coin { get; set; }

        [ForeignKey("CategoryId")]
        public CoinCategory? Category { get; set; }
    }
}