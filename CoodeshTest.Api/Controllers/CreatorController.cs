using CoodeshTest.Application.Dto;
using CoodeshTest.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoodeshTest.Api.Controllers
{
    [Route("api/[controller]")]
    public class CreatorController : Controller
    {
        private readonly ICreatorService _app;

        public CreatorController(ICreatorService app)
        {
            _app = app;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] CreatorDto filters)
        {
            var creators = await _app.GetCreatorsAsync();
            return new JsonResult(creators);
        }

        [HttpGet("{Name}")]
        public async Task<IActionResult> Get(string Name)
        {
            var creators = await _app.GetByName(Name);
            return new JsonResult(creators);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatorDto dto)
        {
            var creators = await _app.Add(dto);
            return new JsonResult(creators);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CreatorDto dto)
        {
            var creators = await _app.Update(dto);
            return new JsonResult(creators);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(CreatorDto dto)
        {
            var creators = await _app.Remove(dto);
            return new JsonResult(creators);
        }
    }
}
