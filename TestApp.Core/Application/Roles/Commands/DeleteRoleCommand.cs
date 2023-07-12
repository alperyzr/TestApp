using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Core.Application.Roles.Commands
{
    public class DeleteRoleCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
