using Microsoft.AspNetCore.Mvc;

namespace TestApp.MVC.Controllers
{
	public class UserRoleController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
