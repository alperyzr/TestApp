using Bentas.O2.DynamicLinq;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApp.Core.Application.UrlShorts.Queries;
using TestApp.Core.Application.UrlShorts.ViewModels;
using TestApp.Core.Application.UrlShorts.Commands;

namespace TestApp.API.Pipeline.UrlShorts
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlShortController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UrlShortController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{Id:int:min(1)}")]
        public async Task<IActionResult> GetUrlShortById([FromRoute] GetUrlShortByIdQuery req)
        {
            var entityId = await _mediator.Send(req);
            return Ok(entityId);
        }

        [HttpPost("listDs")]
        [ProducesResponseType(typeof(BDataSourceResult<ListDsUrlShortView>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ListDsUrlShort([FromBody] ListDsUrlShortQuery req)
        {
            var entityId = await _mediator.Send(req);
            return Ok(entityId);
        }


        [HttpPost]
        public async Task<IActionResult> AddUrlShort([FromBody] AddUrlShortCommand req)
        {
            var entityId = await _mediator.Send(req);
            return Ok(entityId);
        }


        [HttpPut("{Id:int:min(1)}")]
        public async Task<IActionResult> UpdateUrlShort([FromRoute] int Id,
                                                    [FromBody] UpdateUrlShortCommand req)
        {
            req.Id = Id;
            await _mediator.Send(req);
            return Ok();
        }

        [HttpDelete("{Id:int:min(1)}")]
        public async Task<IActionResult> DeleteUrlShort([FromRoute] int Id,
                                                    [FromQuery] DeleteUrlShortCommand req)
        {
            req.Id = Id;
            await _mediator.Send(req);
            return NoContent();
        }
    }
}
