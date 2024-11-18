using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace corvus_backend.Models
{
    [Table("coin_link_relation")]
    public class CoinLinkRelation
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("coin_id")]
        public int CoinId { get; set; }

        [Column("link_id")]
        public int LinkId { get; set; }

        [ForeignKey("CoinId")]
        public Coin Coin { get; set; }

        [ForeignKey("LinkId")]
        public Link Link { get; set; }
    }
}