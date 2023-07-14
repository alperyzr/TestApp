
using Bentas.O2.Core.Attributes;
using Bentas.O2.Core.Interfaces;
using Bentas.O2.DynamicLinq;
using Kendo.Mvc.UI;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestApp.Core.Application.Users.Commands;
using TestApp.Core.Application.Users.Queries;
using TestApp.Core.Application.Users.ViewModels;
using TestApp.Service;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TestApp.MVC.Controllers
{
	public class UserController : Controller
	{
		private readonly IApiClient apiClient;
		private readonly IJsonHelper jsonHelper;

		public UserController(IJsonHelper jsonHelper, IApiClient apiClient)
		{
			this.jsonHelper = jsonHelper;
			this.apiClient = apiClient;
		}

		[CommandPermission(Command = typeof(ListDsUserQuery))]
		public IActionResult Index()
		{
			return View(new UserFilterView());
		}


		[HttpPost]
		public async Task<IActionResult> ListDs([DataSourceRequest] DataSourceRequest request, UserFilterView filterView)
		{
			var filter = jsonHelper.Deserialize<ListDsUserQuery>(jsonHelper.Serialize(request.ToBDatasourceRequest()));

			filter.FilterView = filterView;

			var response = await apiClient.ListDsUserQuery(filter);

			return Json(response);
		}

		
	}
}
