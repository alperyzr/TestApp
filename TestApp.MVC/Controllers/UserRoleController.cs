using Microsoft.AspNetCore.Mvc;
using TestApp.Core.Application.Roles.Queries;
using TestApp.Core.Application.UserRoles.Commands;
using TestApp.Core.Application.UserRoles.Queries;
using TestApp.Core.Application.UserRoles.ViewModels;
using TestApp.Core.Application.Users.Queries;
using TestApp.MVC.Services.Interfaces;

namespace TestApp.MVC.Controllers
{
    
    public class UserRoleController : Controller
	{
        private readonly IUserRoleService _userRoleService;
        private readonly IRoleService _roleService;
        private readonly IUserService _userService;

        public UserRoleController(IUserRoleService userRoleService,
            IRoleService roleService,
            IUserService userService)
        {
            _userRoleService = userRoleService;
            _roleService = roleService;
            _userService = userService;
        }

        [HttpGet("UserRole/Index")]                
        public async Task<IActionResult> Index()
        {
            var model = await _userRoleService.GetAllUserRoles(new GetAllUserRolesQuery());
            return View(model.Payload);
        }


        [HttpGet]        
        public async Task<IActionResult> Add()
        {
            var users = await _userService.GetAllUser(new GetAllUsersQuery());
            List<KeyValuePair<int, string>> userModels = users.Payload.Select(u => new KeyValuePair<int, string>(u.Id, u.FirstName + " " + u.LastName)).ToList();
            ViewBag.Users = userModels;

            var roles = await _roleService.GetAllRole(new GetAllRolesQuery());
            List<KeyValuePair<int, string>> roleModels = roles.Payload.Select(u => new KeyValuePair<int, string>(u.Id, u.Name)).ToList();
            ViewBag.Roles = roleModels;

            return View(new UserRoleView());
        }

        
        [HttpPost]        
        public async Task<IActionResult> Add([FromForm] AddUserRoleCommand req)
        {
            
                var model = await _userRoleService.AddUserRole(req);
                if (model.Code == "200")
                {
                    TempData["success"] = model.Message;
                    return RedirectToAction("Index", "UserRole");
                }
                else
                {
                    TempData["errors"] = model.Message;
                    return RedirectToAction("Add", "UserRole", req);
                }
           

        }

        [HttpGet]        
        public async Task<IActionResult> Update(int? id)
        {
            if (!id.HasValue || id.Value <= 0)
                return RedirectToAction("Index", "UserRole");

            var roles = await _roleService.GetAllRole(new GetAllRolesQuery());
            List<KeyValuePair<int, string>> roleModels = roles.Payload.Select(u => new KeyValuePair<int, string>(u.Id, u.Name)).ToList();
            ViewBag.Roles = roleModels;
            var model = await _userRoleService.GetUserRoleById(new GetUserRoleByIdQuery { Id = (int)id });
            return View(model.Payload);
        }

       
        [HttpPost]        
        public async Task<IActionResult> Update([FromRoute] int Id,
                                                [FromForm] UpdateUserRoleCommand req)
        {
            if (ModelState.IsValid)
            {
                var model = await _userRoleService.UpdateUserRole(Id, req);
                if (model.Code == "200")
                {
                    TempData["success"] = model.Message;
                    return RedirectToAction("Index", "UserRole");
                }
                else
                {
                    TempData["errors"] = model.Message;
                    return RedirectToAction("Update", "UserRole", req);
                }
            }
            else
            {
                return View(req);
            }
            

        }

        
        public async Task<IActionResult> Delete([FromRoute] int Id,
                                                 [FromQuery] DeleteUserRoleCommand req)
        {
            req.Id = Id;
            var model = await _userRoleService.DeleteUserRole(Id, req);
            if (model.Code == "200")
            {
                TempData["success"] = model.Message;
                //return RedirectToAction("Index", "UserRole");
                return Json(model);
            }
            else
            {
                TempData["errors"] = model.Message;
                return Json(model);
            }
        }

        
        public async Task<IActionResult> Detail(int? id)
        {
            if (!id.HasValue || id.Value <= 0)
                return RedirectToAction("Index", "UserRole");

            var model = await _userRoleService.GetUserRoleById(new GetUserRoleByIdQuery { Id = (int)id });
            if (model.Code == "200")
            {
                return View(model.Payload);
            }
            else
            {
                TempData["errors"] = model.Message;
                return RedirectToAction("Index", "UserRole");
            }

        }

       
    }
}
