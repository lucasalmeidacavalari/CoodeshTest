using CoodeshTest.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoodeshTest.Application.Dto
{
    public class TransactionDto
    {
        public int TransactionId { get; private set; }
        public DateTime DateTransaction { get; private set; }
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Price")]
        public decimal Price { get; private set; }
        [DisplayName("Creators")]
        public int CreatorId { get; set; }
        public Creator Creator { get; set; }
        [DisplayName("Affiliates")]
        public int AffiliatedId { get; set; }
        public Affiliated Affiliated { get; set; }
        [DisplayName("Products")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
