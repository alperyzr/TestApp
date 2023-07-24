using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using TestApp.Core.Application;
using TestApp.Core.Application.Login.Queries;
using TestApp.Core.Application.Users.ViewModels;
using TestApp.MVC.Extentions;
using TestApp.MVC.Filters;
using TestApp.MVC.Models;
using TestApp.MVC.Services.Interfaces;
using TestApp.Service;
using static MassTransit.ValidationResultExtensions;

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
                return RedirectToAction("Index", "Home");
        }

        [ValidationFilter]
        [HttpPost]
        public async Task<IActionResult> Index(LoginQuery req)
        {

            if (!string.IsNullOrEmpty(req.Email))
                req.Email = req.Email.ToLower();

            var model = await _loginService.Login(req);
            if (model.Payload != null)
            {
                if (model.Payload.Token != null)
                {
                    SetCookie("Token", model.Payload.Token, 10);
                    HttpContext.Session.SetString("Token", model.Payload.Token);
                    SetCookie("UserKey", model.Payload.UserName, 10);
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    TempData["errors"] = "Kullanıcı Bilgileri Yanlış !";
                    return View(req);
                }
            }
            else
            {
                TempData["errors"] = model.Message;
                return View(req);
            }



        }

        public IActionResult LogOut()
        {
            RemoveCookie("UserKey");
            RemoveCookie("Token");
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
