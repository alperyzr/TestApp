﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Core.Application.UserRoles.ViewModels;

namespace TestApp.Core.Application.UserRoles.Queries
{
    public class GetUserRoleByIdQuery : IRequest<ServiceResult<GetUserRoleByIdDto>>
    {
        public int Id { get; set; }
    }
}
