using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace corvus_backend.Models
{
    [Table("link")]
    public class Link
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("type")]
        [MaxLength(100)]
        public string Type { get; set; }

        [Column("url")]
        [MaxLength(255)]
        public string Url { get; set; }
    }
}