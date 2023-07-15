using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Core.Application.UserRoles.ViewModels;

namespace TestApp.Core.Application.UserRoles.Commands
{
    public class AddUserRoleCommand : UserRoleDto, IRequest<ServiceResult<UserRoleDto>>
    {
    }
}
