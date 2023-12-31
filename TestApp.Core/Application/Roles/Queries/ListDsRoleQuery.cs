﻿
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Core.Application.Roles.ViewModels;

namespace TestApp.Core.Application.Roles.Queries
{
    public class ListDsRoleQuery :  IRequest<ListDsRoleView>
    {
        public RoleFilterView FilterView { get; set; } = new RoleFilterView();
    }
}
