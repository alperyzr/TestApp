using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Core.Application.UrlShorts.ViewModels;

namespace TestApp.Core.Application.UrlShorts.Commands
{
    public class UpdateUrlShortCommand : UrlShortDto, IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
