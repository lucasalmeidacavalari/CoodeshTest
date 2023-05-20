using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoodeshTest.Application.Dto
{
    public class AffiliatedDto
    {
        public int AffiliatedId { get; private set; }
        [Required(ErrorMessage = "The name is required!")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; private set; }
    }
}
