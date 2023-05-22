using CoodeshTest.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoodeshTest.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
        Task<ProductDto> GetByName(string? name);
        Task<ProductDto> Add(ProductDto product);
        Task<ProductDto> Update(ProductDto product);
        Task<ProductDto> Remove(ProductDto product);
    }
}
