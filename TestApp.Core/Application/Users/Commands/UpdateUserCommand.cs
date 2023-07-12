using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Core.Application.Users.ViewModels;

namespace TestApp.Core.Application.Users.Commands
{
    public class UpdateUserCommand: UserDto, IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
