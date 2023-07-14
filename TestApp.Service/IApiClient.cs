using Bentas.O2.DynamicLinq;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TestApp.Core.Application.Login.Queries;
using TestApp.Core.Application.Users.Commands;
using TestApp.Core.Application.Users.Queries;
using TestApp.Core.Application.Users.ViewModels;

namespace TestApp.Service
{
	public interface IApiClient
	{

		[Post("login/login")]
		Task<UserDto> Login(LoginQuery model);

		[Post("api/v1/wsUrl/listDs")]		
		Task<BDataSourceResult<ListDsUserView>> ListDsUserQuery(ListDsUserQuery model);

		
	}
}
