using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Core.Application.Roles.ViewModels;
using TestApp.Core.Application.Users.ViewModels;
using TestApp.Core.Application.Login.ViewModels;

namespace TestApp.Core.Application.Login.Queries
{
	public class LoginQuery : IRequest<ServiceResult<AccessToken>>
	{
		[Required(ErrorMessage = "Email alanı boş geçilemez")]		
		[DisplayName("Email")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Şifre alanı boş geçilemez")]
		[DisplayName("Şifre")]
		[DataType("Password")]
		public string Password { get; set; }
	}
}
