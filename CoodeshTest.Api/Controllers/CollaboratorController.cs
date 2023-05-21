using CoodeshTest.Application.Dto;
using CoodeshTest.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoodeshTest.Api.Controllers
{
    [Route("api/[controller]")]
    public class CollaboratorController : Controller
    {
        private readonly ICollaboratorService _app;

        public CollaboratorController(ICollaboratorService app)
        {
            _app = app;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] CollaboratorDto filters)
        {
            var collaborator = await _app.GetCollaborator(filters);
            return new JsonResult(collaborator);
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
        {
            var collaborator = await _app.GetByEmail(email);
            return new JsonResult(collaborator);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CollaboratorDto dto)
        {
            var collaborator = await _app.Add(dto);
            return new JsonResult(collaborator);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CollaboratorDto dto)
        {
            var collaborator = await _app.Update(dto);
            return new JsonResult(collaborator);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(CollaboratorDto dto)
        {
            var collaborator = await _app.Remove(dto);
            return new JsonResult(collaborator);
        }
    }
}
