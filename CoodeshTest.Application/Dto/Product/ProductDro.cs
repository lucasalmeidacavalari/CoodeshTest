using CoodeshTest.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoodeshTest.Application.Dto
{
    public class ProductDro
    {
        public int ProductId { get; private set; }
        [Required(ErrorMessage = "The name is required!")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; private set; }
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Price")]
        public decimal Price { get; private set; }
        [DisplayName("Creators")]
        public int CreatorId { get; set; }
        public Creator Creator { get; set; }
    }
}
