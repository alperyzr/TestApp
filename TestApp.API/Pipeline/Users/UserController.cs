using Bentas.O2.DynamicLinq;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApp.Core.Application.Users.Commands;
using TestApp.Core.Application.Users.Queries;
using TestApp.Core.Application.Users.ViewModels;

namespace TestApp.API.Pipeline.Users
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{Id:int:min(1)}")]
        public async Task<IActionResult> GetUserById([FromRoute] GetUserByIdQuery req)
        {
            var model = await _mediator.Send(req);
            return Ok(model);
        }

        [HttpPost]
        [ProducesResponseType(typeof(BDataSourceResult<ListDsUserView>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ListDs([FromBody] ListDsUserQuery req)
        {
            var model = await _mediator.Send(req);
            return Ok(model);
        }


        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] AddUserCommand req)
        {
            var model = await _mediator.Send(req);
            return Ok(model);
        }


        [HttpPut("{Id:int:min(1)}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int Id,
                                                    [FromBody] UpdateUserCommand req)
        {
            req.Id = Id;
            var model = await _mediator.Send(req);
            return Ok(model);
        }

        [HttpDelete("{Id:int:min(1)}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int Id,
                                                    [FromQuery] DeleteUserCommand req)
        {
            req.Id = Id;
            var model = await _mediator.Send(req);
            return Ok(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers([FromBody] GetAllUsersQuery req)
        {
            var model = await _mediator.Send(req);
            return Ok(model);
        }
    }
}
