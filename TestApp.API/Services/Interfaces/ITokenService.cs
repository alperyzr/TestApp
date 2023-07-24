
using TestApp.Core.Application.Login.ViewModels;
using TestApp.Core.Entities;

namespace TestApp.API.Services.Interfaces
{
    public interface ITokenService
    {
        AccessToken CreateAccessToken(User user);
        void RevokeRefreshToken(User user);
    }
}
