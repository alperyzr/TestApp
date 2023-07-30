using Microsoft.AspNetCore.Mvc;
using TestApp.MVC.Services.Interfaces;
using TestApp.Core.Application.UrlShorts.Queries;
using TestApp.Core.Application.UrlShorts.Commands;
using TestApp.Core.Application.UserRoles.ViewModels;
using TestApp.Core.Application.Users.Queries;
using Microsoft.AspNetCore.Authorization;
using Kendo.Mvc.UI;
using TestApp.Core.Application.Users.ViewModels;
using Bentas.O2.Core.Interfaces;
using TestApp.Core.Application.UrlShorts.ViewModels;
using Bentas.O2.DynamicLinq;

namespace TestApp.MVC.Controllers
{
    
    public class UrlShortController : Controller
    {
        private readonly IUrlShortService _urlShortService;
        private readonly IUserService _userService;
        private readonly IJsonHelper _jsonHelper;


        public UrlShortController(IUrlShortService urlShortService,
            IUserService userService,
            IJsonHelper jsonHelper)
        {
            _urlShortService = urlShortService;
            _userService = userService;
            _jsonHelper = jsonHelper;
        }


        [HttpGet("UrlShort/Index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ListDs([DataSourceRequest] DataSourceRequest request, UrlShortFilterView filterView)
        {
            var filter = _jsonHelper.Deserialize<ListDsUrlShortQuery>(_jsonHelper.Serialize(request.ToBDatasourceRequest()));
            filter.FilterView = filterView;

            var response = await _urlShortService.ListDsUrlShortQuery(filter);

            return Json(response);
        }


        [HttpGet]        
        public async Task<IActionResult> Add()
        {
            var users = await _userService.GetAllUser(new GetAllUsersQuery());
            List<KeyValuePair<int, string>> userModels = users.Payload.Select(u => new KeyValuePair<int, string>(u.Id, u.FirstName + " " + u.LastName)).ToList();
            ViewBag.Users = userModels;
            return View(new UrlShortView());
        }

       
        [HttpPost]        
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
                return RedirectToAction("Add", "UrlShort");
            }

        }

        [HttpGet]       
        public async Task<IActionResult> Update(int? id)
        {
            if (!id.HasValue || id.Value <= 0)
                return RedirectToAction("Index", "UrlShort");


            var model = await _urlShortService.GetUrlShortById(new GetUrlShortByIdQuery { Id = (int)id });
            return View(model.Payload);
        }

        
        [HttpPost]        
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
                return RedirectToAction("Update", "UrlShort",req);
            }

        }

       
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
