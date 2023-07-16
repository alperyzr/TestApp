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
		private readonly IHttpContextAccessor _httpContextAccessor;
		private string ApiUrl => _configuration["ApiUrl"];

		public LoginController(HttpClient httpClient, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
		{
			_httpClient = httpClient;
			_configuration = configuration;
			_httpContextAccessor = httpContextAccessor;
		}


		public IActionResult Index()
		{
			var userKey = GetCookie("UserKey");
			if (String.IsNullOrEmpty(userKey))			
				return View();
			else
				return RedirectToAction("Index","Home");
		}

		[HttpPost]
		public async Task<IActionResult> Index(LoginQuery loginModel)
		{
			var model = await _httpClient.CustomPostAsync<ServiceResult<UserDto>>($"{ApiUrl}/login/login", loginModel);
			if (model.Code != "200")
				return View(model);

			SetCookie("UserKey",model.Payload.FirstName + " "+ model.Payload.LastName,10);

			return RedirectToAction("Index", "Home");
			
		}

		/// <summary>  
		/// Get the cookie  
		/// </summary>  
		/// <param name="key">Key </param>  
		/// <returns>string value</returns>  
		public string GetCookie(string key)
		{
			return Request.Cookies[key];
		}
		/// <summary>  
		/// set the cookie  
		/// </summary>  
		/// <param name="key">key (unique indentifier)</param>  
		/// <param name="value">value to store in cookie object</param>  
		/// <param name="expireTime">expiration time</param>  
		public void SetCookie(string key, string value, int? expireTime)
		{
			CookieOptions option = new CookieOptions();
			if (expireTime.HasValue)
				option.Expires = DateTime.Now.AddDays(expireTime.Value);
			else
				option.Expires = DateTime.Now.AddDays(10);
			Response.Cookies.Append(key, value, option);
		}
		/// <summary>  
		/// Delete the key  
		/// </summary>  
		/// <param name="key">Key</param>  
		public void RemoveCookie(string key)
		{
			Response.Cookies.Delete(key);
		}


	}
}
