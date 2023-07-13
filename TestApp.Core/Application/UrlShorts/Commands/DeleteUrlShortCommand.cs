using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Core.Application.UrlShorts.Commands
{
    public class DeleteUrlShortCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
