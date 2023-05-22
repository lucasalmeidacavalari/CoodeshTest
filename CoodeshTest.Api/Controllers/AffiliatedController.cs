using CoodeshTest.Application.Dto;
using CoodeshTest.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoodeshTest.Api.Controllers
{
    [Route("api/[controller]")]
    public class AffiliatedController : Controller
    {
        private readonly IAffiliatedService _app;

        public AffiliatedController(IAffiliatedService app)
        {
            _app = app;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] AffiliatedDto filters)
        {
            var affiliated = await _app.GetAffiliateds();
            return new JsonResult(affiliated);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var affiliated = await _app.GetByName(name);
            return new JsonResult(affiliated);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AffiliatedDto dto)
        {
            var affiliated = await _app.Add(dto);
            return new JsonResult(affiliated);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] AffiliatedDto dto)
        {
            var affiliated = await _app.Update(dto);
            return new JsonResult(affiliated);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(AffiliatedDto dto)
        {
            var affiliated = await _app.Remove(dto);
            return new JsonResult(affiliated);
        }
    }
}
