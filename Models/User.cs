using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace corvus_backend.Models
{
    [Table("user")]
    public class User
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("username")]
        [MaxLength(100)]
        public string Username { get; set; }

        [Column("email")]
        [MaxLength(100)]
        public string Email { get; set; }

        [Column("password_hash")]
        [MaxLength(255)]
        public string PasswordHash { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}