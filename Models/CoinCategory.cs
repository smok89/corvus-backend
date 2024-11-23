using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace corvus_backend.Models
{
    [Table("coin_category")]
    public class CoinCategory : BaseEntity
    {
        [Column("name")]
        [MaxLength(100)]
        public string? Name { get; set; }
    }
}