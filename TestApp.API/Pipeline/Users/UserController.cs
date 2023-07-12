using Bentas.O2.DynamicLinq;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApp.Core.Application.Users.Commands;
using TestApp.Core.Application.Users.Queries;
using TestApp.Core.Application.Users.ViewModels;

namespace TestApp.API.Pipeline.Users
{
    [Route("api/[controller]")]
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
            var entityId = await _mediator.Send(req);
            return Ok(entityId);
        }

        [HttpPost("listDs")]
        [ProducesResponseType(typeof(BDataSourceResult<ListDsUserView>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ListDsUser([FromBody] ListDsUserQuery req)
        {           
            var entityId = await _mediator.Send(req);
            return Ok(entityId);
        }


        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] AddUserCommand req)
        {            
            var entityId = await _mediator.Send(req);
            return Ok(entityId);
        }


        [HttpPut("{Id:int:min(1)}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int Id,
                                                    [FromBody] UpdateUserCommand req)
        {            
            req.Id = Id;
            await _mediator.Send(req);
            return Ok();
        }

        [HttpDelete("{Id:int:min(1)}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int Id,
                                                    [FromQuery] DeleteUserCommand req)
        {
            req.Id = Id;
            await _mediator.Send(req);
            return NoContent();
        }
    }
}
