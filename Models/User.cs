using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace corvus_backend.Models
{
    [Table("user")]
    public class User : BaseEntity
    {
        [Column("username")]
        [MaxLength(100)]
        public string? Username { get; set; }

        [Column("email")]
        [MaxLength(100)]
        public string? Email { get; set; }

        [Column("password_hash")]
        [MaxLength(255)]
        public string? PasswordHash { get; set; }

    }
}