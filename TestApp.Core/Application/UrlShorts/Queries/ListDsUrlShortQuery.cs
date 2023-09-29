
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Core.Application.UrlShorts.ViewModels;

namespace TestApp.Core.Application.UrlShorts.Queries
{
    public class ListDsUrlShortQuery : IRequest<ListDsUrlShortView>
    {
        public UrlShortFilterView FilterView { get; set; } = new UrlShortFilterView();
    }
}
