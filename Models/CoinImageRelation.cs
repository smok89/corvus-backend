using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace corvus_backend.Models
{
    [Table("coin_image_relation")]
    public class CoinImageRelation
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("coin_id")]
        public int CoinId { get; set; }

        [Column("image_id")]
        public int ImageId { get; set; }

        [ForeignKey("CoinId")]
        public Coin Coin { get; set; }

        [ForeignKey("ImageId")]
        public Image Image { get; set; }
    }
}