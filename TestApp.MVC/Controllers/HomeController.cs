﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestApp.Core.Application.UrlShorts.Queries;
using TestApp.MVC.Models;
using TestApp.MVC.Services.Interfaces;

namespace TestApp.MVC.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUrlShortService _urlShortService;

        public HomeController(ILogger<HomeController> logger,
            IUrlShortService urlShortService)
        {
            _logger = logger;
            _urlShortService = urlShortService;
        }

        [HttpGet("Home/Index")]
        public IActionResult Index()
        {
            return View();
        }

        
        public async Task<IActionResult> Short([FromRoute] string ShortUrl)
        {

            var model = await _urlShortService.GetUrlShortInfoByShortUrl(new GetUrlShortInfoByShortUrlQuery { ShortUrl = ShortUrl });
            if (model.Payload != null)
            {
                var uri = new Uri(model.Payload.Url);
                return Redirect(uri.AbsoluteUri);
            }
            TempData["errors"] = model.Message;
            return RedirectToAction("Index","Home");

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}