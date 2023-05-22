using CoodeshTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoodeshTest.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetByName(string? name);
        Task<Product> Add(Product product);
        Task<Product> Update(Product product);
        Task<Product> Remove(Product product);
    }
}
