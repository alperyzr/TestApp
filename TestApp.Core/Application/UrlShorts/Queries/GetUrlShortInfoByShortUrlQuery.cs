using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Core.Application.UrlShorts.ViewModels;

namespace TestApp.Core.Application.UrlShorts.Queries
{
    public class GetUrlShortInfoByShortUrlQuery : IRequest<ServiceResult<UrlShortDto>>
    {
        public string ShortUrl { get; set; }
    }
}
