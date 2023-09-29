
using MediatR;
using TestApp.Core.Application;
using TestApp.Core.Application.Users.Commands;
using TestApp.Core.Application.Users.Queries;
using TestApp.Core.Application.Users.ViewModels;

namespace TestApp.MVC.Services.Interfaces
{
    public interface IUserService
    {
        Task<ServiceResult<UserDto>> AddUser(AddUserCommand req);
        Task<ServiceResult<Unit>> DeleteUser(int Id, DeleteUserCommand req);
        Task<ServiceResult<UserDto>> UpdateUser(int Id, UpdateUserCommand req);
        Task<ServiceResult<UserDto>> GetUserById(GetUserByIdQuery req);
        //Task<BDataSourceResult<ListDsUserView>> ListDsUserQuery(ListDsUserQuery req);
        Task<ServiceResult<List<UserDto>>> GetAllUser(GetAllUsersQuery req);
    }
}
