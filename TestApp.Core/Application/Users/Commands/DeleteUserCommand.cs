using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Core.Application.Users.Commands
{
    public class DeleteUserCommand: IRequest<ServiceResult<Unit>>
    {
        public int Id { get; set; }
    }
}
