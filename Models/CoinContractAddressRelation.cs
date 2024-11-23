using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace corvus_backend.Models
{
    [Table("coin_contract_address_relation")]
    public class CoinContractAddressRelation : BaseEntity
    {
        [Column("coin_id")]
        public int CoinId { get; set; }

        [Column("contract_address_id")]
        public int ContractAddressId { get; set; }

        [ForeignKey("CoinId")]
        public Coin? Coin { get; set; }

        [ForeignKey("ContractAddressId")]
        public ContractAddress? ContractAddress { get; set; }
    }
}