using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Core.Application.Roles.ViewModels;

namespace TestApp.Core.Application.Roles.Commands
{
    public class UpdateRoleCommand : RoleDto, IRequest<ServiceResult<RoleDto>>
    {
        public int Id { get; set; }
    }
}
