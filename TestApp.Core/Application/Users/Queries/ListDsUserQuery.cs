
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Core.Application.Users.ViewModels;

namespace TestApp.Core.Application.Users.Queries
{
    public class ListDsUserQuery: IRequest<ListDsUserView>
    {
		public UserFilterView FilterView { get; set; } = new UserFilterView();
	}
}
