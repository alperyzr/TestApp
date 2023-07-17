
using Bentas.O2.Core.Attributes;
using Bentas.O2.Core.Interfaces;
using Bentas.O2.DynamicLinq;
using Bentas.O2.WebExtensions.Interfaces;
using Bentas.O2.WebExtensions.Models;
using Bentas.O2.WebExtensions.Services;
using Kendo.Mvc.UI;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestApp.Core.Application.UserRoles.Queries;
using TestApp.Core.Application.Users.Commands;
using TestApp.Core.Application.Users.Queries;
using TestApp.Core.Application.Users.ViewModels;
using TestApp.MVC.Services.Interfaces;
using TestApp.Service;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TestApp.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [CommandPermission(Command = typeof(ListDsUserQuery))]
        public async Task<IActionResult> Index()
        {
            var model = await _userService.GetAllUser(new GetAllUsersQuery());
            return View(model.Payload);
        }


        [HttpGet]
        [CommandPermission(Command = typeof(AddUserCommand))]
        public async Task<IActionResult> Add()
        {
            return View("Modify", new UserView());
        }

        [HttpPost]
        [CommandPermission(Command = typeof(AddUserCommand))]
        public async Task<IActionResult> Add([FromBody] AddUserCommand req)
        {

            var model = await _userService.AddUser(req);
            return Json(new JsonResponse { IsSuccess = model.Code == "200" ? true : false, Data = model.Payload });

        }

        [HttpGet]
        [CommandPermission(Command = typeof(UpdateUserCommand))]
        public async Task<IActionResult> Update(int? id)
        {
            if (!id.HasValue || id.Value <= 0)
                return RedirectToAction("Index");


            var model = await _userService.GetUserById(new GetUserByIdQuery { Id = (int)id });
            return View("Modify", model.Payload);
        }

        [HttpPost]
        [CommandPermission(Command = typeof(UpdateUserCommand))]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommand req)
        {
            var model = await _userService.UpdateUser(req.Id, req);
            return Json(new JsonResponse { IsSuccess = model.Code == "200" ? true : false, Data = model.Payload });

        }

        [CommandPermission(Command = typeof(DeleteUserCommand))]
        public async Task<IActionResult> Delete([FromRoute] int Id,
                                                 [FromQuery] DeleteUserCommand req)
        {
            req.Id = Id;
            var model = await _userService.DeleteUser(Id, req);
            return Json(new JsonResponse { IsSuccess = model.Code == "200" ? true : false, Data = model.Payload });
        }

        [CommandPermission(Command = typeof(GetUserByIdQuery))]
        public async Task<IActionResult> Detail(int? id)
        {
            if (!id.HasValue || id.Value <= 0)
                return RedirectToAction("Index");

            var model = await _userService.GetUserById(new GetUserByIdQuery { Id = (int)id});
            return View(model);
        }

    }
}
