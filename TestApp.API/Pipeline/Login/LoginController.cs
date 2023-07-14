
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using TestApp.MVC.Security;
using TestApp.Core.Application.Login.Queries;

namespace TestApp.API.Pipeline.Login
{
	public class LoginController : Controller
	{
		
		[HttpPost]
		[Route("/login")]
		public async Task<IActionResult> Login(LoginQuery loginReqest)
		{
			return Ok();

		}

	}
}
