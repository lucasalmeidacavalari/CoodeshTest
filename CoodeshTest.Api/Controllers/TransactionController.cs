using CoodeshTest.Application.Dto;
using CoodeshTest.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CoodeshTest.Api.Controllers
{
    [Route("api/[controller]")]
    public class TransactionController : Controller
    {
        private readonly ITransactionService _app;

        public TransactionController(ITransactionService app)
        {
            _app = app;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] TransactionDto filters)
        {
            var transactions = await _app.GetTransactions();
            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                IgnoreNullValues = true,
                WriteIndented = true,
            };

            var jsonString = JsonSerializer.Serialize(transactions, jsonOptions);
            return Ok(jsonString);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var transactions = await _app.GetById(id);
            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                IgnoreNullValues = true,
                WriteIndented = true,
            };

            var jsonString = JsonSerializer.Serialize(transactions, jsonOptions);
            return Ok(jsonString);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TransactionDto dto)
        {
            var transactions = await _app.Add(dto);
            return new JsonResult(transactions);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] TransactionDto dto)
        {
            var transactions = await _app.Update(dto);
            return new JsonResult(transactions);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(TransactionDto dto)
        {
            var transactions = await _app.Remove(dto);
            return new JsonResult(transactions);
        }
    }
}
