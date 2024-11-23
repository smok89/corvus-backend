using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace corvus_backend.Models
{
    [Table("platform")]
    public class Platform : BaseEntity
    {
        [Column("name")]
        [MaxLength(100)]
        public string? Name { get; set; }
    }
}