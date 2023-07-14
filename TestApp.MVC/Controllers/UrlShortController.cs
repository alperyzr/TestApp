using Microsoft.AspNetCore.Mvc;

namespace TestApp.MVC.Controllers
{
	public class UrlShortController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
