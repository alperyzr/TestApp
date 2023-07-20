using Bentas.O2.Core.Attributes;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using TestApp.MVC.Services.Interfaces;
using TestApp.Core.Application.UrlShorts.Queries;
using TestApp.Core.Application.UrlShorts.Commands;
using TestApp.Core.Application.UserRoles.ViewModels;
using TestApp.Core.Application.Users.Queries;
using TestApp.MVC.Services;

namespace TestApp.MVC.Controllers
{
    public class UrlShortController : Controller
    {
        private readonly IUrlShortService _urlShortService;
        private readonly IUserService _userService;

        public UrlShortController(IUrlShortService urlShortService,
            IUserService userService)
        {
            _urlShortService = urlShortService;
            _userService = userService;
        }

        [CommandPermission(Command = typeof(ListDsUrlShortQuery))]
        public async Task<IActionResult> Index()
        {
            var model = await _urlShortService.GetAllUrlShorts(new GetAllUrlShortsQuery());
            return View(model.Payload);
        }


        [HttpGet]
        [CommandPermission(Command = typeof(AddUrlShortCommand))]
        public async Task<IActionResult> Add()
        {
            var users = await _userService.GetAllUser(new GetAllUsersQuery());
            List<KeyValuePair<int, string>> userModels = users.Payload.Select(u => new KeyValuePair<int, string>(u.Id, u.FirstName + " " + u.LastName)).ToList();
            ViewBag.Users = userModels;
            return View(new UrlShortView());
        }

        [HttpPost]
        [CommandPermission(Command = typeof(AddUrlShortCommand))]
        public async Task<IActionResult> Add([FromForm] AddUrlShortCommand req)
        {

            var model = await _urlShortService.AddUrlShort(req);
            if (model.Code == "200")
            {
                TempData["success"] = model.Message;
                return RedirectToAction("Index", "UrlShort");
            }
            else
            {
                TempData["errors"] = model.Message;
                return RedirectToAction("Index", "UrlShort");
            }

        }

        [HttpGet]
        [CommandPermission(Command = typeof(UpdateUrlShortCommand))]
        public async Task<IActionResult> Update(int? id)
        {
            if (!id.HasValue || id.Value <= 0)
                return RedirectToAction("Index", "UrlShort");


            var model = await _urlShortService.GetUrlShortById(new GetUrlShortByIdQuery { Id = (int)id });
            return View(model.Payload);
        }

        [HttpPost]
        [CommandPermission(Command = typeof(UpdateUrlShortCommand))]
        public async Task<IActionResult> Update([FromRoute] int Id,
                                                [FromForm] UpdateUrlShortCommand req)
        {
            var model = await _urlShortService.UpdateUrlShort(Id, req);
            if (model.Code == "200")
            {
                TempData["success"] = model.Message;
                return RedirectToAction("Index", "UrlShort");
            }
            else
            {
                TempData["errors"] = model.Message;
                return RedirectToAction("Index", "UrlShort");
            }

        }

        [CommandPermission(Command = typeof(DeleteUrlShortCommand))]
        public async Task<IActionResult> Delete([FromRoute] int Id,
                                                 [FromQuery] DeleteUrlShortCommand req)
        {
            req.Id = Id;
            var model = await _urlShortService.DeleteUrlShort(Id, req);
            if (model.Code == "200")
            {
                TempData["success"] = model.Message;                
                return Json(model);
            }
            else
            {
                TempData["errors"] = model.Message;
                return Json(model);
            }
        }

        [CommandPermission(Command = typeof(GetUrlShortByIdQuery))]
        public async Task<IActionResult> Detail(int? id)
        {
            if (!id.HasValue || id.Value <= 0)
                return RedirectToAction("Index", "UrlShort");

            var model = await _urlShortService.GetUrlShortById(new GetUrlShortByIdQuery { Id = (int)id });
            if (model.Code == "200")
            {
                return View(model.Payload);
            }
            else
            {
                TempData["errors"] = model.Message;
                return RedirectToAction("Index", "UrlShort");
            }

        }

    }
}
