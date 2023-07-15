using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestApp.Core.Application;
using TestApp.Core.Application.Login.Queries;
using TestApp.Core.Application.Users.ViewModels;
using TestApp.MVC.Extentions;
using TestApp.MVC.Models;
using TestApp.Service;

namespace TestApp.MVC.Controllers
{
	public class LoginController : Controller
	{
		private readonly HttpClient _httpClient;
		private readonly IConfiguration _configuration;		
		private string ApiUrl => _configuration["ApiUrl"];

		public LoginController(HttpClient httpClient, IConfiguration configuration)
		{
			_httpClient = httpClient;
			_configuration = configuration;
		}


		public IActionResult Index()
		{

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(LoginQuery loginModel)
		{
			var model = await _httpClient.CustomPostAsync<ServiceResult<UserDto>>($"{ApiUrl}/login/login", loginModel);
			if (model.Code != "200")
				return View(model);
			return RedirectToAction("Index", "Home");
			
		}


	}
}
