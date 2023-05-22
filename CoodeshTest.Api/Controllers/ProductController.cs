using CoodeshTest.Application.Dto;
using CoodeshTest.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Xml;
using System.Net.Http.Json;
using System.Text.Json;

namespace CoodeshTest.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _app;

        public ProductController(IProductService app)
        {
            _app = app;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ProductDto filters)
        {
            var products = await _app.GetProducts();
            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                IgnoreNullValues = true,
                WriteIndented = true,
            };

            var jsonString = JsonSerializer.Serialize(products, jsonOptions);
            return Ok(jsonString);
        }


        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var products = await _app.GetByName(name);
            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                IgnoreNullValues = true,
                WriteIndented = true,
            };

            var jsonString = JsonSerializer.Serialize(products, jsonOptions);
            return Ok(jsonString);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductDto dto)
        {
            var products = await _app.Add(dto);
            return new JsonResult(products);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProductDto dto)
        {
            var products = await _app.Update(dto);
            return new JsonResult(products);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(ProductDto dto)
        {
            var products = await _app.Remove(dto);
            return new JsonResult(products);
        }
    }
}
