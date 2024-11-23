using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace corvus_backend.Models
{
    [Table("contract_address")]
    public class ContractAddress : BaseEntity
    {
        [Column("address")]
        [MaxLength(100)]
        public string? Address { get; set; }
    }
}