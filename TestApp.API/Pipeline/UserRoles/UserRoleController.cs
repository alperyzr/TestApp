﻿using Bentas.O2.DynamicLinq;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApp.Core.Application.UserRoles.Commands;
using TestApp.Core.Application.UserRoles.Queries;
using TestApp.Core.Application.UserRoles.ViewModels;

namespace TestApp.API.Pipeline.UserRoleRoles
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserRoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{Id:int:min(1)}")]
        public async Task<IActionResult> GetUserRoleRoleById([FromRoute] GetUserRoleByIdQuery req)
        {
            var entityId = await _mediator.Send(req);
            return Ok(entityId);
        }

        [HttpPost("listDs")]
        [ProducesResponseType(typeof(BDataSourceResult<ListDsUserRoleView>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ListDsUserRole([FromBody] ListDsUserRoleQuery req)
        {
            var entityId = await _mediator.Send(req);
            return Ok(entityId);
        }


        [HttpPost]
        public async Task<IActionResult> AddUserRole([FromBody] AddUserRoleCommand req)
        {
            var entityId = await _mediator.Send(req);
            return Ok(entityId);
        }


        [HttpPut("{Id:int:min(1)}")]
        public async Task<IActionResult> UpdateUserRole([FromRoute] int Id,
                                                    [FromBody] UpdateUserRoleCommand req)
        {
            req.Id = Id;
            await _mediator.Send(req);
            return Ok();
        }

        [HttpDelete("{Id:int:min(1)}")]
        public async Task<IActionResult> DeleteUserRole([FromRoute] int Id,
                                                    [FromQuery] DeleteUserRoleCommand req)
        {
            req.Id = Id;
            await _mediator.Send(req);
            return NoContent();
        }
    }
}
