using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Core.Application.Roles.ViewModels;


namespace TestApp.Core.Application.Roles.Commands
{
    public class AddRoleCommand : RoleDto, IRequest<ServiceResult<RoleDto>>
    {
    }
}
