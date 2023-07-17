using TestApp.Core.Application;
using TestApp.Core.Application.Login.Queries;
using TestApp.Core.Application.Users.ViewModels;

namespace TestApp.MVC.Services.Interfaces
{
    public interface ILoginService
    {
        Task<ServiceResult<UserDto?>> Login(LoginQuery req);
    }
}
