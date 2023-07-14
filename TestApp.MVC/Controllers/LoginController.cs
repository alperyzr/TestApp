using Microsoft.AspNetCore.Mvc;
using TestApp.Core.Application.Login.Queries;
using TestApp.MVC.Models;
using TestApp.Service;

namespace TestApp.MVC.Controllers
{
	public class LoginController : Controller
	{
		private readonly IApiClient apiClient;

		public LoginController(IApiClient apiClient)
		{
			this.apiClient = apiClient;
		}


		public IActionResult Index()
		{

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(LoginQuery loginModel)
		{
			var response = await apiClient.Login(loginModel);
			if (response == null)
			{
				return View();
			}
			return RedirectToAction("Index", "Home");

		}


	}
}
