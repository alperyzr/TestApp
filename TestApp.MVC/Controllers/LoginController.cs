using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using TestApp.Core.Application;
using TestApp.Core.Application.Login.Queries;
using TestApp.Core.Application.Users.ViewModels;
using TestApp.MVC.Extentions;
using TestApp.MVC.Models;
using TestApp.MVC.Services.Interfaces;
using TestApp.Service;

namespace TestApp.MVC.Controllers
{
	public class LoginController : Controller
	{
		private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
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
		public async Task<IActionResult> Index(LoginQuery req)
		{			
			var model = await _loginService.Login(req);
            if (model.Code != "200")
                return View(model);

            SetCookie("UserKey", model.Payload.FirstName + " " + model.Payload.LastName, 10);

            return RedirectToAction("Index", "Home");

        }

        public IActionResult LogOut()
        {
			RemoveCookie("UserKey");
			return RedirectToAction("Index");
        }

        
        public string GetCookie(string key)
		{
			return Request.Cookies[key];
		}
		
		public void SetCookie(string key, string value, int? expireTime)
		{
			CookieOptions option = new CookieOptions();
			if (expireTime.HasValue)
				option.Expires = DateTime.Now.AddDays(expireTime.Value);
			else
				option.Expires = DateTime.Now.AddDays(10);
			Response.Cookies.Append(key, value, option);
		}
		
		public void RemoveCookie(string key)
		{
			Response.Cookies.Delete(key);
		}


	}
}
