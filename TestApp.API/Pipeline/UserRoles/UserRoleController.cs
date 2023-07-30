using Bentas.O2.DynamicLinq;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApp.Core.Application.UserRoles.Commands;
using TestApp.Core.Application.UserRoles.Queries;
using TestApp.Core.Application.UserRoles.ViewModels;
using TestApp.Core.Application.Users.Queries;

namespace TestApp.API.Pipeline.UserRoleRoles
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserRoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{Id:int:min(1)}")]
        public async Task<IActionResult> GetUserRoleById([FromRoute] GetUserRoleByIdQuery req)
        {
            var model = await _mediator.Send(req);
            return Ok(model);
        }

        [HttpPost()]
        [ProducesResponseType(typeof(BDataSourceResult<ListDsUserRoleView>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ListDs([FromBody] ListDsUserRoleQuery req)
        {
            var model = await _mediator.Send(req);
            return Ok(model);
        }


        [HttpPost]
        public async Task<IActionResult> AddUserRole([FromBody] AddUserRoleCommand req)
        {
            var model = await _mediator.Send(req);
            return Ok(model);
        }


        [HttpPut("{Id:int:min(1)}")]
        public async Task<IActionResult> UpdateUserRole([FromRoute] int Id,
                                                        [FromBody] UpdateUserRoleCommand req)
        {
            req.Id = Id;
            var model = await _mediator.Send(req);
            return Ok(model);
        }

        [HttpDelete("{Id:int:min(1)}")]
        public async Task<IActionResult> DeleteUserRole([FromRoute] int Id,
                                                        [FromQuery] DeleteUserRoleCommand req)
        {
            req.Id = Id;
            var model = await _mediator.Send(req);
            return Ok(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUserRoles([FromBody] GetAllUserRolesQuery req)
        {
            var model = await _mediator.Send(req);
            return Ok(model);
        }
    }
}
