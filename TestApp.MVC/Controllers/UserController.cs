using Bentas.O2.DynamicLinq;
using Kendo.Mvc.Infrastructure;
using Kendo.Mvc;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using TestApp.Core.Application.UserRoles.Queries;
using TestApp.Core.Application.Users.Commands;
using TestApp.Core.Application.Users.Queries;
using TestApp.Core.Application.Users.ViewModels;
using TestApp.MVC.Filters;
using TestApp.MVC.Services;
using TestApp.MVC.Services.Interfaces;
using Kendo.Mvc.Extensions;
using TestApp.Repository;
using System.Collections;

namespace TestApp.MVC.Controllers
{

    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly Bentas.O2.Core.Interfaces.IJsonHelper _jsonHelper;
        private readonly AppDbContext _appDbContext;

        public UserController(IUserService userService, Bentas.O2.Core.Interfaces.IJsonHelper jsonHelper, AppDbContext appDbContext)
        {
            _userService = userService;
            _jsonHelper = jsonHelper;
            _appDbContext = appDbContext;
        }

        

        [HttpGet("User/Index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ListDs([DataSourceRequest] DataSourceRequest request, UserFilterView filterView)
        {
            var filter = _jsonHelper.Deserialize<ListDsUserQuery>(_jsonHelper.Serialize(request.ToBDatasourceRequest()));
            filter.FilterView = filterView;

            var response = await _userService.ListDsUserQuery(filter);

            return Json(response);
        }


        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View(new UserView());
        }

        [ValidationFilter]
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] AddUserCommand req)
        {

            var model = await _userService.AddUser(req);
            if (model.Code == "200")
            {
                TempData["success"] = model.Message;
                return RedirectToAction("Index", "User");
            }
            else
            {
                TempData["errors"] = model.Message;
                return RedirectToAction("Add", "User", req);
            }

        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (!id.HasValue || id.Value <= 0)
                return RedirectToAction("Index", "User");


            var model = await _userService.GetUserById(new GetUserByIdQuery { Id = (int)id });
            return View(model.Payload);
        }

        [ValidationFilter]
        [HttpPost]
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
                return RedirectToAction("Update", "User", req);
            }

        }

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


        public async Task<IActionResult> Detail(int? id)
        {
            if (!id.HasValue || id.Value <= 0)
                return RedirectToAction("Index", "User");

            var model = await _userService.GetUserById(new GetUserByIdQuery { Id = (int)id });
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
