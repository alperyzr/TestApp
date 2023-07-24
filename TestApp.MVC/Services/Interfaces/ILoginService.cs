using TestApp.Core.Application;
using TestApp.Core.Application.Login.Queries;
using TestApp.Core.Application.Login.ViewModels;
using TestApp.Core.Application.Users.ViewModels;

namespace TestApp.MVC.Services.Interfaces
{
    public interface ILoginService
    {
        Task<ServiceResult<AccessToken?>> Login(LoginQuery req);
    }
}
