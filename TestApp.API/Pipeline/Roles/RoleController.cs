using Bentas.O2.DynamicLinq;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApp.Core.Application.Roles.Commands;
using TestApp.Core.Application.Roles.Queries;
using TestApp.Core.Application.Roles.ViewModels;
using TestApp.Core.Application.UserRoles.Queries;

namespace TestApp.API.Pipeline.Roles
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{Id:int:min(1)}")]
        public async Task<IActionResult> GetRoleById([FromRoute] GetRoleByIdQuery req)
        {
            var entityId = await _mediator.Send(req);
            return Ok(entityId);
        }

        [HttpPost("listDs")]
        [ProducesResponseType(typeof(BDataSourceResult<ListDsRoleView>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ListDsRole([FromBody] ListDsRoleQuery req)
        {
            var entityId = await _mediator.Send(req);
            return Ok(entityId);
        }


        [HttpPost]
        public async Task<IActionResult> AddRole([FromBody] AddRoleCommand req)
        {
            var entityId = await _mediator.Send(req);
            return Ok(entityId);
        }


        [HttpPut("{Id:int:min(1)}")]
        public async Task<IActionResult> UpdateRole([FromRoute] int Id,
                                                    [FromBody] UpdateRoleCommand req)
        {
            req.Id = Id;
            await _mediator.Send(req);
            return Ok();
        }

        [HttpDelete("{Id:int:min(1)}")]
        public async Task<IActionResult> DeleteRole([FromRoute] int Id,
                                                    [FromQuery] DeleteRoleCommand req)
        {
            req.Id = Id;
            await _mediator.Send(req);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoles([FromBody] GetAllRolesQuery req)
        {
            var model = await _mediator.Send(req);
            return Ok(model);
        }
    }
}
