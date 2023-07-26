using Bentas.O2.DynamicLinq;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using TestApp.Core.Application.Users.Commands;
using TestApp.Core.Application.Users.Queries;
using TestApp.Core.Application.Users.ViewModels;
using TestApp.MVC.Filters;
using TestApp.MVC.Services.Interfaces;


namespace TestApp.MVC.Controllers
{
    //[Authorize("Admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly Bentas.O2.Core.Interfaces.IJsonHelper _jsonHelper;

        public UserController(IUserService userService, Bentas.O2.Core.Interfaces.IJsonHelper jsonHelper)
        {
            _userService = userService;
            _jsonHelper = jsonHelper;
        }

        //[Route("User/Index")]
        //[CommandPermission(Command = typeof(ListDsUserQuery))]
        //public async Task<IActionResult> Index()
        //{
        //    var model = await _userService.GetAllUser(new GetAllUsersQuery());
        //    return View(model.Payload);
        //}

        [HttpGet("User/Index")]              
        public IActionResult Index()
        {
            return View(new UserFilterView());
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
