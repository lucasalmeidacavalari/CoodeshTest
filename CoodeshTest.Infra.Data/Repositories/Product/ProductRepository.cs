using CoodeshTest.Domain.Entities;
using CoodeshTest.Domain.Interfaces;
using CoodeshTest.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoodeshTest.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _ctx;

        public ProductRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Product> Add(Product product)
        {
            _ctx.Add(product);
            await _ctx.SaveChangesAsync();
            return product;
        }
        public async Task<Product> Remove(Product product)
        {
            _ctx.Remove(product);
            await _ctx.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Update(Product product)
        {
            _ctx.Update(product);
            await _ctx.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetById(int? productId)
        {
            return await _ctx.Products.Include(_ => _.Creator).Where(_ => _.ProductId == productId).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _ctx.Products.Include(_ => _.Creator).ToListAsync();
        }
        
    }
}
