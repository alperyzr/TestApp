
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

        [Route("User/Index")]
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
            return View(new UserView());
        }

        [HttpPost]
        [CommandPermission(Command = typeof(AddUserCommand))]
        public async Task<IActionResult> Add([FromForm] AddUserCommand req)
        {

            var model = await _userService.AddUser(req);
            if(model.Code == "200")
            {
                TempData["success"] = model.Message;
                return RedirectToAction("Index", "User");
            }
            else
            {
                TempData["errors"] = model.Message;
                return RedirectToAction("Index", "User");
            }

        }

        [HttpGet]
        [CommandPermission(Command = typeof(UpdateUserCommand))]
        public async Task<IActionResult> Update(int? id)
        {
            if (!id.HasValue || id.Value <= 0)
                return RedirectToAction("Index", "User");


            var model = await _userService.GetUserById(new GetUserByIdQuery { Id = (int)id });
            return View(model.Payload);
        }

        [HttpPost]
        [CommandPermission(Command = typeof(UpdateUserCommand))]
        public async Task<IActionResult> Update([FromRoute] int Id, 
                                                [FromForm] UpdateUserCommand req)
        {
            var model = await _userService.UpdateUser(Id, req);
            if (model.Code == "200")
            {
                TempData["success"] = model.Message;
                return RedirectToAction("Index", "User");
            }
            else
            {
                TempData["errors"] = model.Message;
                return RedirectToAction("Index", "User");
            }

        }

        [CommandPermission(Command = typeof(DeleteUserCommand))]
        public async Task<IActionResult> Delete([FromRoute] int Id,
                                                 [FromQuery] DeleteUserCommand req)
        {
            req.Id = Id;
            var model = await _userService.DeleteUser(Id, req);
            if (model.Code == "200")
            {
                TempData["success"] = model.Message;
                //return RedirectToAction("Index", "User");
                return Json(model);
            }
            else
            {
                TempData["errors"] = model.Message;
                return Json(model);
            }
        }

        [CommandPermission(Command = typeof(GetUserByIdQuery))]
        public async Task<IActionResult> Detail(int? id)
        {
            if (!id.HasValue || id.Value <= 0)
                return RedirectToAction("Index", "User");

            var model = await _userService.GetUserById(new GetUserByIdQuery { Id = (int)id});
            if (model.Code == "200")
            {              
                return View(model.Payload);
            }
            else
            {
                TempData["errors"] = model.Message;
                return RedirectToAction("Index", "User");
            }
            
        }

    }
}
