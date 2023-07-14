using Microsoft.AspNetCore.Mvc;

namespace TestApp.MVC.Controllers
{
	public class RoleController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
