using CoodeshTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoodeshTest.Application.Dto
{
    public class CreatorDto
    {
        public int CreatorId { get; set; }
        public string Name { get; set; }
    }
}
