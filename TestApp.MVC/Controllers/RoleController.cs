using Bentas.O2.Core.Attributes;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using TestApp.MVC.Services.Interfaces;
using TestApp.Core.Application.Roles.Queries;
using TestApp.Core.Application.Roles.Commands;
using TestApp.Core.Application.Roles.ViewModels;

namespace TestApp.MVC.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [CommandPermission(Command = typeof(ListDsRoleQuery))]
        public async Task<IActionResult> Index()
        {
            var model = await _roleService.GetAllRole(new GetAllRolesQuery());
            return View(model.Payload);
        }


        [HttpGet]
        [CommandPermission(Command = typeof(AddRoleCommand))]
        public async Task<IActionResult> Add()
        {
            return View(new RoleView());
        }

        [HttpPost]
        [CommandPermission(Command = typeof(AddRoleCommand))]
        public async Task<IActionResult> Add([FromForm] AddRoleCommand req)
        {

            var model = await _roleService.AddRole(req);
            if (model.Code == "200")
            {
                TempData["success"] = model.Message;
                return RedirectToAction("Index", "Role");
            }
            else
            {
                TempData["errors"] = model.Message;
                return RedirectToAction("Index", "Role");
            }

        }

        [HttpGet]
        [CommandPermission(Command = typeof(UpdateRoleCommand))]
        public async Task<IActionResult> Update(int? id)
        {
            if (!id.HasValue || id.Value <= 0)
                return RedirectToAction("Index", "Role");


            var model = await _roleService.GetRoleById(new GetRoleByIdQuery { Id = (int)id });
            return View(model.Payload);
        }

        [HttpPost]
        [CommandPermission(Command = typeof(UpdateRoleCommand))]
        public async Task<IActionResult> Update([FromRoute] int Id,
                                                [FromForm] UpdateRoleCommand req)
        {
            var model = await _roleService.UpdateRole(Id, req);
            if (model.Code == "200")
            {
                TempData["success"] = model.Message;
                return RedirectToAction("Index", "Role");
            }
            else
            {
                TempData["errors"] = model.Message;
                return RedirectToAction("Index", "Role");
            }

        }

        [CommandPermission(Command = typeof(DeleteRoleCommand))]
        public async Task<IActionResult> Delete([FromRoute] int Id,
                                                 [FromQuery] DeleteRoleCommand req)
        {
            req.Id = Id;
            var model = await _roleService.DeleteRole(Id, req);
            if (model.Code == "200")
            {
                TempData["success"] = model.Message;
                //return RedirectToAction("Index", "Role");
                return Json(model);
            }
            else
            {
                TempData["errors"] = model.Message;
                return Json(model);
            }
        }

        [CommandPermission(Command = typeof(GetRoleByIdQuery))]
        public async Task<IActionResult> Detail(int? id)
        {
            if (!id.HasValue || id.Value <= 0)
                return RedirectToAction("Index", "Role");

            var model = await _roleService.GetRoleById(new GetRoleByIdQuery { Id = (int)id });
            if (model.Code == "200")
            {
                return View(model.Payload);
            }
            else
            {
                TempData["errors"] = model.Message;
                return RedirectToAction("Index", "Role");
            }

        }

    }
}
