using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Core.Entities;

namespace TestApp.Core.Application.UrlShorts.ViewModels
{
    public class GetUrlShortByIdDto : _BaseDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Url { get; set; }
        public string ShortUrl { get; set; }
        public string Description { get; set; }
        public string ToRedirectUrl { get; set; }
        public DateTime RedirectUrlDate { get; set; }
        public string UserName { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
    }
}
