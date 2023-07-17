
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using TestApp.MVC.Security;
using TestApp.Core.Application.Login.Queries;
using TestApp.Core.Application.Users.Commands;
using MediatR;

namespace TestApp.API.Pipeline.Login
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class LoginController : Controller
	{
		private readonly IMediator _mediator;

		public LoginController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]		
		public async Task<IActionResult> Login([FromBody] LoginQuery req)
		{
			var model = await _mediator.Send(req);
			return Ok(model);

		}
		
	}
}
