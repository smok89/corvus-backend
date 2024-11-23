using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace corvus_backend.Models
{
    [Table("image")]
    public class Image : BaseEntity
    {
        [Column("type")]
        [MaxLength(100)]
        public string? Type { get; set; }

        [Column("path")]
        [MaxLength(255)]
        public string? Path { get; set; }
    }
}