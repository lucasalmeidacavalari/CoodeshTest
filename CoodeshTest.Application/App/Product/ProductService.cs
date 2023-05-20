using AutoMapper;
using CoodeshTest.Application.Dto;
using CoodeshTest.Application.Interfaces;
using CoodeshTest.Domain.Entities;
using CoodeshTest.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CoodeshTest.Application.App
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _rep;
        private readonly IMapper _map;

        public ProductService(IProductRepository rep, IMapper map)
        {
            _rep = rep;
            _map = map;
        }

        public async Task<ProductDto> Add(ProductDto product)
        {
            var _product = _map.Map<Product>(product);
            await _rep.Add(_product);
            return product;
        }
        public async Task<ProductDto> Remove(ProductDto product)
        {
            var _product = _rep.GetById(product.ProductId).Result;
            await _rep.Remove(_product);
            return product;
        }

        public async Task<ProductDto> Update(ProductDto product)
        {
            var _product = _map.Map<Product>(product);
            await _rep.Update(_product);
            return product;
        }

        public async Task<ProductDto> GetById(int? productId)
        {
            var _product = await _rep.GetById(productId);
            return _map.Map<ProductDto>(_product);
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var _product = await _rep.GetProducts();
            return _map.Map<IEnumerable<ProductDto>>(_product);
        }
        
    }
}
